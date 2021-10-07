using Domain.Models;
using Gallery.Shared.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Gallery.Application.Queries
{
    public abstract class GetShowsListQuery : QueryRequest, IRequest<List<ShowDTO>>
    {
        public int Page { get; set; }
    }
}
