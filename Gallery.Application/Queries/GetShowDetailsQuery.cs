using Domain.Models;
using MediatR;

namespace Gallery.Application.Queries
{
    public abstract class GetShowDetailsQuery<T> : QueryRequest, IRequest<T>
    {
        public int ShowId { get; set; }
    }
}
