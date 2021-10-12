using AutoMapper;
using Gallery.Application.Dtos;
using Gallery.Application.Queries;
using Gallery.Domain;
using Gallery.Domain.AggregatesModel.MovieAggregate;
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
        private IMediator _mediator;

        public GetMoviesByGenreHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
            _mediator = mediator;
        }

        public async Task<List<ShowDTO>> Handle(GetMoviesByGenreQuery query, CancellationToken cancellationToken)
        {
            //var request = new RestRequest(query.Query)
            //    .AddParameter("api_key", query.ApiKey)
            //    .AddParameter("sort_by", "popularity.desc")
            //    .AddParameter("with_genres", query.GenreId)
            //    .AddParameter("page", query.Page);
            //var response = await _client.GetAsync<MoviesResponse>(request);

            //var movies = response.Results;

            //var genresList = await MoviesGenres.GetGenresList(query.ApiKey);

            //foreach (var movie in movies)
            //{
            //    movie.Genres = new List<string>();
            //    foreach (var genreId in movie.GenreIds)
            //    {
            //        var genre = genresList.Find((gnr) => gnr.Id == genreId);
            //        if (genre != null)
            //        {
            //            movie.Genres.Add(genre.Name);
            //        }
            //    }
            //}

            //return _mapper.Map<List<MovieToGet>, List<ShowDTO>>(movies);

            var request = new RestRequest(query.Query)
                .AddParameter("api_key", query.ApiKey)
                .AddParameter("sort_by", "popularity.desc")
                .AddParameter("with_genres", query.GenreId)
                .AddParameter("page", query.Page);
            var response = await _client.GetAsync<MoviesResponse>(request);

            var movies = new List<Movie>();

            var genresList = await MoviesGenres.GetGenresList(query.ApiKey);

            foreach(var mv in response.Results)
            {
                var genres = new List<Genre>();

                foreach(var genreId in mv.GenreIds)
                {
                    var genre = genresList.Find((gnr) => gnr.Id == genreId);
                    if(genre != null)
                    {
                        genres.Add(genre);
                    }
                }

                var movie = new Movie(
                    mv.Id.ToString(),
                    mv.Title,
                    mv.VoteAverage,
                    mv.ReleaseDate,
                    mv.OriginalLanguage,
                    mv.Overview,
                    mv.PosterPath,
                    genres
                );

                var domainEvents = movie.GetDomainEvents();

                foreach (var domainEvent in domainEvents)
                {
                    await _mediator.Publish(domainEvent);
                }

                movies.Add(movie);
            }

            return _mapper.Map<List<Movie>, List<ShowDTO>>(movies);
        }
    }
}
