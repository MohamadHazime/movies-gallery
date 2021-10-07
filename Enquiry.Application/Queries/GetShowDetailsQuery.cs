using Core.Models;
using MediatR;

namespace Enquiry.Application.Queries
{
    public abstract class GetShowDetailsQuery<T> : QueryRequest, IRequest<T>
    {
        public int ShowId { get; set; }
    }
}
