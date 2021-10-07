using System.Collections.Generic;

namespace Domain.Models
{
    public class TVShowDetails : ShowDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double VoteAverage { get; set; }
        public List<Genre> Genres { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public string FirstAirDate { get; set; }
        public List<Season> Seasons { get; set; }
        public List<string> OriginCountry { get; set; }
    }
}