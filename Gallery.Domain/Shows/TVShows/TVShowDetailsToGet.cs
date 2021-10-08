using System.Collections.Generic;

namespace Gallery.Domain
{
    public class TVShowDetailsToGet : ShowDetailsToGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double VoteAverage { get; set; }
        public List<GenreToGet> Genres { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public List<ProductionCompanyToGet> ProductionCompanies { get; set; }
        public string FirstAirDate { get; set; }
        public List<SeasonToGet> Seasons { get; set; }
        public List<string> OriginCountry { get; set; }
    }
}