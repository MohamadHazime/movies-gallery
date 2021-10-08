using Gallery.Application.Dtos;
using Gallery.Domain;
using MediatR;
using System.Collections.Generic;

namespace Gallery.Application.Commands
{
    public class AddMoviesListCommand : IRequest<List<ShowDTO>>
    {
        public List<ShowDTO> Movies { get; set; }
    }
}
