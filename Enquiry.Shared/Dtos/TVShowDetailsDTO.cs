using Core;
using System.Collections.Generic;

namespace Enquiry.Shared.Dtos
{
    public class TVShowDetailsDTO : ShowDetailsDTO
    {
        public List<Season> Seasons { get; set; }
    }
}