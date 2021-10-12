using AutoMapper;
using Gallery.Application.Commands;
using Gallery.Domain;
using Gallery.Domain.AggregatesModel.MovieAggregate;
using Gallery.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, Movie>
    {
        private readonly IMovieRepository _moviesService;
        private readonly IMapper _mapper;

        public AddMovieHandler(IMovieRepository moviesService, IMapper mapper)
        {
            _moviesService = moviesService;
            _mapper = mapper;
        }

        public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var genres = new List<Genre>();

            //var genresList = await MoviesGenres.GetGenresList(request.GetApiKey());

            //foreach (var genreName in request.Genres)
            //{
            //    var genre = genresList.Find((gnr) => gnr.Name == genreName);

            //    if(genre != null)
            //    {
            //        genres.Add(genre);
            //    }
            //}

            var movie = new Movie(
                null,
                request.Title,
                request.VoteAverage,
                null,
                request.OriginCountry,
                request.Overview,
                request.PosterPath,
                genres
            );

            return await _moviesService.AddAsync(movie);
        }
    }
}
