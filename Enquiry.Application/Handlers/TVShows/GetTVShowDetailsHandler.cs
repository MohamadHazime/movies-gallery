﻿using AutoMapper;
using Core.Dtos;
using Core.Models;
using Enquiry.Application.Queries;
using MediatR;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace Enquiry.Application.Handlers
{
    public class GetTVShowDetailsHandler : IRequestHandler<GetTVShowDetailsQuery, TVShowDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly RestClient _client;

        public GetTVShowDetailsHandler(IMapper mapper)
        {
            _mapper = mapper;
            _client = MyRestClient.GetRestClientObject();
        }

        public async Task<TVShowDetailsDTO> Handle(GetTVShowDetailsQuery query, CancellationToken cancellationToken)
        {
            var request = new RestRequest(query.Query + "/" + query.ShowId)
                .AddParameter("api_key", query.ApiKey);
            var response = await _client.GetAsync<TVShowDetails>(request);

            return _mapper.Map<TVShowDetails, TVShowDetailsDTO>(response);
        }
    }
}
