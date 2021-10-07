using System.Collections.Generic;

namespace Domain.Models
{
    public abstract class Show
    {
        public int Id { get; set; }
        public double VoteAverage { get; set; }
        public string OriginalLanguage { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public List<int> GenreIds { get; set; }
        public List<string> Genres { get; set; }
    }
}
