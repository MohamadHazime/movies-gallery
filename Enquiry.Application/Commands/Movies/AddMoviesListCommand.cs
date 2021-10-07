using Core.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Enquiry.Application.Commands
{
    public class AddMoviesListCommand : IRequest<List<ShowDTO>>
    {
        public List<ShowDTO> Movies { get; set; }
    }
}
