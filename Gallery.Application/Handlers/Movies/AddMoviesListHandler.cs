using Gallery.Application.Commands;
using Gallery.Infrastructure.Repositories;
using Gallery.Shared.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddMoviesListHandler : IRequestHandler<AddMoviesListCommand, List<ShowDTO>>
    {
        private readonly IMongoShowsRepository<MovieDetailsDTO> _mongoMoviesService;

        public AddMoviesListHandler(IMongoShowsRepository<MovieDetailsDTO> mongoMoviesService)
        {
            _mongoMoviesService = mongoMoviesService;
        }

        public async Task<List<ShowDTO>> Handle(AddMoviesListCommand request, CancellationToken cancellationToken)
        {
            return await _mongoMoviesService.AddAllAsync(request.Movies);
        }
    }
}
