using Core.Dtos;
using Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Enquiry.Application.Queries
{
    public abstract class GetShowsListQuery : QueryRequest, IRequest<List<ShowDTO>>
    {
        public int Page { get; set; }
    }
}
