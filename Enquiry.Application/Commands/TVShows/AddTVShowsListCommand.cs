using Core.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Enquiry.Application.Commands
{
    public class AddTVShowsListCommand : IRequest<List<ShowDTO>>
    {
        public List<ShowDTO> TvShows { get; set; }
    }
}
