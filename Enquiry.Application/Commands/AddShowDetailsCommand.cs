using MediatR;

namespace Enquiry.Application.Commands
{
    public abstract class AddShowDetailsCommand<T> : IRequest<T>
    {
        public T ShowDetails { get; set; }
    }
}
