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
    public class GetTVShowsByGenreHandler : IRequestHandler<GetTVShowsByGenreQuery, List<ShowDTO>>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetTVShowsByGenreHandler(IMapper mapper)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<List<ShowDTO>> Handle(GetTVShowsByGenreQuery query, CancellationToken cancellationToken)
        {
            var request = new RestRequest(query.Query)
                .AddParameter("api_key", query.ApiKey)
                .AddParameter("sort_by", "popularity.desc")
                .AddParameter("with_genres", query.GenreId)
                .AddParameter("page", query.Page);
            var response = await _client.GetAsync<TVShowsResponse>(request);

            var tvShows = response.Results;

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
