using Gallery.Domain.AggregatesModel.MovieAggregate;
using System.Collections.Generic;

namespace Gallery.Application.Dtos
{
    public class ShowDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public string OriginCountry { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
