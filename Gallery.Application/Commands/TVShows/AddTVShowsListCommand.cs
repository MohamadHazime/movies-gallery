using Gallery.Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Gallery.Application.Commands
{
    public class AddTVShowsListCommand : IRequest<List<ShowDTO>>
    {
        public List<ShowDTO> TvShows { get; set; }
    }
}
