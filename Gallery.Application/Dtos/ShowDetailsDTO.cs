using Gallery.Domain;
using System.Collections.Generic;

namespace Gallery.Application.Dtos
{
    public abstract class ShowDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public List<GenreToGet> Genres { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public List<ProductionCompanyToGet> ProductionCompanies { get; set; }
        public string ReleaseDate { get; set; }
        public string OriginCountry { get; set; }
    }
}