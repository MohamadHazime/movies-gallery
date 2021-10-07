using Core.Dtos;
using Enquiry.Application.Commands;
using Enquiry.Infrastructure.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Enquiry.Application.Handlers
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
