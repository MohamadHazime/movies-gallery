using Gallery.Application.Commands;
using Gallery.Infrastructure.Repositories;
using Gallery.Shared.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddTVShowDetailsHandler : IRequestHandler<AddTVShowDetailsCommand, TVShowDetailsDTO>
    {
        private readonly IMongoShowsRepository<TVShowDetailsDTO> _mongoTVShowService;

        public AddTVShowDetailsHandler(IMongoShowsRepository<TVShowDetailsDTO> mongoTVShowService)
        {
            _mongoTVShowService = mongoTVShowService;
        }

        public async Task<TVShowDetailsDTO> Handle(AddTVShowDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _mongoTVShowService.AddDetailsAsync(request.ShowDetails);
        }
    }
}
