using Gallery.Domain;
using System.Collections.Generic;

namespace Gallery.Application.Dtos
{
    public class TVShowDetailsDTO : ShowDetailsDTO
    {
        public List<SeasonToGet> Seasons { get; set; }
    }
}