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
    public class GetTopRatedTVShowsHandler : IRequestHandler<GetTopRatedTVShowsQuery, List<ShowDTO>>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetTopRatedTVShowsHandler(IMapper mapper)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<List<ShowDTO>> Handle(GetTopRatedTVShowsQuery query, CancellationToken cancellationToken)
        {
            var request = new RestRequest(query.Query)
                .AddParameter("api_key", query.ApiKey)
                .AddParameter("page", query.Page);
            var response = await _client.GetAsync<TVShowsResponse>(request);

            var tvShows = response.Results.GetRange(0, 6);

            var genresList = await TVShowsGenres.GetGenresList(query.ApiKey);

            foreach (var tvShow in tvShows)
            {
                tvShow.Genres = new List<string>();
                foreach (var genreId in tvShow.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if (genre != null)
                    {
                        tvShow.Genres.Add(genre.Name);
                    }
                }
            }

            return _mapper.Map<List<TVShow>, List<ShowDTO>>(tvShows);
        }
    }
}
