using Domain.Models;
using System.Collections.Generic;

namespace Gallery.Shared.Dtos
{
    public class TVShowDetailsDTO : ShowDetailsDTO
    {
        public List<Season> Seasons { get; set; }
    }
}