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
    public class AddTVShowHandler : IRequestHandler<AddTVShowCommand, TVShowToAdd>
    {
        private readonly IMongoShowsRepository<TVShowToAdd> _mongoMoviesService;
        private readonly IMapper _mapper;

        public AddTVShowHandler(IMongoShowsRepository<TVShowToAdd> mongoMoviesService, IMapper mapper)
        {
            _mongoMoviesService = mongoMoviesService;
            _mapper = mapper;
        }

        public async Task<TVShowToAdd> Handle(AddTVShowCommand request, CancellationToken cancellationToken)
        {
            var tvShow = _mapper.Map<AddTVShowCommand, TVShowToAdd>(request);

            return await _mongoMoviesService.AddAsync(tvShow);
        }
    }
}
