using Gallery.Application.Commands;
using Gallery.Infrastructure.Repositories;
using Gallery.Shared.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class AddTVShowsListHandler : IRequestHandler<AddTVShowsListCommand, List<ShowDTO>>
    {
        private readonly IMongoShowsRepository<TVShowDetailsDTO> _mongoTVShowsService;

        public AddTVShowsListHandler(IMongoShowsRepository<TVShowDetailsDTO> mongoTVShowsService)
        {
            _mongoTVShowsService = mongoTVShowsService;
        }

        public async Task<List<ShowDTO>> Handle(AddTVShowsListCommand request, CancellationToken cancellationToken)
        {
            return await _mongoTVShowsService.AddAllAsync(request.TvShows);
        }
    }
}
