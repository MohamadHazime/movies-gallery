using AutoMapper;
using Domain.Models;
using Gallery.Application.Queries;
using Gallery.Shared.Dtos;
using MediatR;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace Gallery.Application.Handlers
{
    public class GetMovieDetailsHandler : IRequestHandler<GetMovieDetailsQuery, MovieDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetMovieDetailsHandler(IMapper mapper)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<MovieDetailsDTO> Handle(GetMovieDetailsQuery query, CancellationToken cancellationToken)
        {
            var request = new RestRequest(query.Query + "/" + query.ShowId)
                .AddParameter("api_key", query.ApiKey);
            var response = await _client.GetAsync<MovieDetails>(request);

            return _mapper.Map<MovieDetails, MovieDetailsDTO>(response);
        }
    }
}
