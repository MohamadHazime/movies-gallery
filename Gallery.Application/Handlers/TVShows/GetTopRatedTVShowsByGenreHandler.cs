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
    public class GetTopRatedTVShowsByGenreHandler : IRequestHandler<GetTopRatedTVShowsByGenreQuery, List<ShowDTO>>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetTopRatedTVShowsByGenreHandler(IMapper mapper)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<List<ShowDTO>> Handle(GetTopRatedTVShowsByGenreQuery query, CancellationToken cancellationToken)
        {
            var tvShows = new List<TVShow>();
            int page = query.Page;

            while (tvShows.Count < 3)
            {
                var request = new RestRequest(query.Query)
                    .AddParameter("api_key", query.ApiKey)
                    .AddParameter("page", page);
                var response = await _client.GetAsync<TVShowsResponse>(request);

                tvShows.AddRange(response.Results.FindAll((movie) => movie.GenreIds.Contains(query.GenreId)));

                page++;
            }

            tvShows = tvShows.GetRange(0, 3);

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
