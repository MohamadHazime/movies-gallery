using Core.Dtos;
using Enquiry.Application.Commands;
using Enquiry.Infrastructure.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Enquiry.Application.Handlers
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
