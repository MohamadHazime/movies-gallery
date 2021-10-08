using AutoMapper;
using Gallery.Application.Commands;
using Gallery.Domain;
using Gallery.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, MovieToAdd>
    {
        private readonly IMongoShowsRepository<MovieToAdd> _mongoMoviesService;
        private readonly IMapper _mapper;

        public AddMovieHandler(IMongoShowsRepository<MovieToAdd> mongoMoviesService, IMapper mapper)
        {
            _mongoMoviesService = mongoMoviesService;
            _mapper = mapper;
        }

        public async Task<MovieToAdd> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<AddMovieCommand, MovieToAdd>(request);

            return await _mongoMoviesService.AddAsync(movie);
        }
    }
}
