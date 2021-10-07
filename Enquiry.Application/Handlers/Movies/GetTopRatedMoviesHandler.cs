using AutoMapper;
using Core.Dtos;
using Core.Models;
using Enquiry.Application.Queries;
using MediatR;
using RestSharp;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Enquiry.Application.Handlers
{
    public class GetTopRatedMoviesHandler : IRequestHandler<GetTopRatedMoviesQuery, List<ShowDTO>>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetTopRatedMoviesHandler(IMapper mapper) 
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<List<ShowDTO>> Handle(GetTopRatedMoviesQuery query, CancellationToken cancellationToken)
        {
            var request = new RestRequest(query.Query)
                .AddParameter("api_key", query.ApiKey)
                .AddParameter("page", query.Page);
            var response = await _client.GetAsync<MoviesResponse>(request);

            var movies = response.Results.GetRange(0, 6);

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
