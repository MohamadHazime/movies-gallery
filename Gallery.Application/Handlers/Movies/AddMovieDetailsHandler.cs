using Gallery.Application.Commands;
using Gallery.Infrastructure.Repositories;
using Gallery.Shared.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddMovieDetailsHandler : IRequestHandler<AddMovieDetailsCommand, MovieDetailsDTO>
    {
        private readonly IMongoShowsRepository<MovieDetailsDTO> _mongoMoviesService;

        public AddMovieDetailsHandler(IMongoShowsRepository<MovieDetailsDTO> mongoMoviesService)
        {
            _mongoMoviesService = mongoMoviesService;
        }

        public async Task<MovieDetailsDTO> Handle(AddMovieDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _mongoMoviesService.AddDetailsAsync(request.ShowDetails);
        }
    }
}
