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
    public class AddTVShowsListHandler : IRequestHandler<AddTVShowsListCommand, List<ShowDTO>>
    {
        private readonly IMongoShowsRepository<TVShowToAdd> _mongoTVShowsService;
        private readonly IMapper _mapper;

        public AddTVShowsListHandler(IMongoShowsRepository<TVShowToAdd> mongoTVShowsService, IMapper mapper)
        {
            _mongoTVShowsService = mongoTVShowsService;
            _mapper = mapper;
        }

        public async Task<List<ShowDTO>> Handle(AddTVShowsListCommand request, CancellationToken cancellationToken)
        {
            var tvShowsList = _mapper.Map<List<ShowDTO>, List<TVShowToAdd>>(request.TvShows);

            await _mongoTVShowsService.AddAllAsync(tvShowsList);

            return request.TvShows;
        }
    }
}
