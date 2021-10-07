using AutoMapper;
using Domain.Models;
using Gallery.Application.Queries;
using Gallery.Shared.Dtos;
using MediatR;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class GetTopRatedMoviesByGenreHandler : IRequestHandler<GetTopRatedMoviesByGenreQuery, List<ShowDTO>>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetTopRatedMoviesByGenreHandler(IMapper mapper)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<List<ShowDTO>> Handle(GetTopRatedMoviesByGenreQuery query, CancellationToken cancellationToken)
        {
            var movies = new List<Movie>();
            int page = query.Page;

            while (movies.Count < 3)
            {
                var request = new RestRequest(query.Query)
                    .AddParameter("api_key", query.ApiKey)
                    .AddParameter("page", page);
                var response = await _client.GetAsync<MoviesResponse>(request);

                movies.AddRange(response.Results.FindAll((movie) => movie.GenreIds.Contains(query.GenreId)));

                page++;
            }

            movies = movies.GetRange(0, 3);

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

            return _mapper.Map<List<Movie>, List<ShowDTO>>(movies);
        }
    }
}
