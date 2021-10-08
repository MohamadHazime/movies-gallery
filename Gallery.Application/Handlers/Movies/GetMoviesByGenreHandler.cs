using AutoMapper;
using Gallery.Application.Dtos;
using Gallery.Application.Queries;
using Gallery.Domain;
using MediatR;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class GetMoviesByGenreHandler : IRequestHandler<GetMoviesByGenreQuery, List<ShowDTO>>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetMoviesByGenreHandler(IMapper mapper)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<List<ShowDTO>> Handle(GetMoviesByGenreQuery query, CancellationToken cancellationToken)
        {
            var request = new RestRequest(query.Query)
                .AddParameter("api_key", query.ApiKey)
                .AddParameter("sort_by", "popularity.desc")
                .AddParameter("with_genres", query.GenreId)
                .AddParameter("page", query.Page);
            var response = await _client.GetAsync<MoviesResponse>(request);

            var movies = response.Results;

            var genresList = await MoviesGenres.GetGenresList(query.ApiKey);

            foreach (var movie in movies)
            {
                movie.Genres = new List<string>();
                foreach (var genreId in movie.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if (genre != null)
                    {
                        movie.Genres.Add(genre.Name);
                    }
                }
            }

            return _mapper.Map<List<MovieToGet>, List<ShowDTO>>(movies);
        }
    }
}
