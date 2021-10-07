using Core.Models;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class TVShowDetailsDTO : ShowDetailsDTO
    {
        public List<Season> Seasons { get; set; }
    }
}