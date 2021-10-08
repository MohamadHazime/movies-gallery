using AutoMapper;
using Gallery.Application.Commands;
using Gallery.Application.Dtos;
using Gallery.Domain;
using Gallery.Infrastructure.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddMoviesListHandler : IRequestHandler<AddMoviesListCommand, List<ShowDTO>>
    {
        private readonly IMongoShowsRepository<MovieToAdd> _mongoMoviesService;
        private readonly IMapper _mapper;

        public AddMoviesListHandler(IMongoShowsRepository<MovieToAdd> mongoMoviesService, IMapper mapper)
        {
            _mongoMoviesService = mongoMoviesService;
            _mapper = mapper;
        }

        public async Task<List<ShowDTO>> Handle(AddMoviesListCommand request, CancellationToken cancellationToken)
        {
            var moviesList = _mapper.Map<List<ShowDTO>, List<MovieToAdd>>(request.Movies);

            await _mongoMoviesService.AddAllAsync(moviesList);

            return request.Movies;
        }
    }
}
