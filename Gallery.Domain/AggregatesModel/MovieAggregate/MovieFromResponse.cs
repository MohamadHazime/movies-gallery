using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Domain.AggregatesModel.MovieAggregate
{
    public class MovieFromResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public string OriginalLanguage { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
