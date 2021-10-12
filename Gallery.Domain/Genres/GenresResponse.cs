using Gallery.Domain.AggregatesModel.MovieAggregate;
using System.Collections.Generic;

namespace Gallery.Domain
{
    class GenresResponse
    {
        public List<Genre> Genres { get; set; }
    }
}