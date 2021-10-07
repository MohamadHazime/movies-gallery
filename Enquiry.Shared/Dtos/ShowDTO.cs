using System.Collections.Generic;

namespace Enquiry.Shared.Dtos
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
        public List<string> Genres { get; set; }
    }
}
