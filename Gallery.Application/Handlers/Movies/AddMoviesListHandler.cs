using AutoMapper;
using Gallery.Application.Commands;
using Gallery.Application.Dtos;
using Gallery.Domain;
using Gallery.Domain.AggregatesModel.MovieAggregate;
using Gallery.Infrastructure.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddMoviesListHandler : IRequestHandler<AddMoviesListCommand, List<ShowDTO>>
    {
        private readonly IMovieRepository _moviesService;
        private readonly IMapper _mapper;

        public AddMoviesListHandler(IMovieRepository moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        public async Task<List<ShowDTO>> Handle(AddMoviesListCommand request, CancellationToken cancellationToken)
        {
            var moviesList = new List<Movie>();

            foreach(var movie in request.Movies)
            {
                moviesList.Add(new Movie(
                    movie.Id.ToString(),
                    movie.Title,
                    movie.VoteAverage,
                    movie.ReleaseDate,
                    movie.OriginCountry,
                    movie.Overview,
                    movie.PosterPath,
                    movie.Genres
                ));
            }

            await _moviesService.AddAllAsync(moviesList);

            return request.Movies;
        }
    }
}
