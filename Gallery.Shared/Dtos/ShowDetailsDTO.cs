using Domain.Models;
using System.Collections.Generic;

namespace Gallery.Shared.Dtos
{
    public abstract class ShowDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public List<Genre> Genres { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public string ReleaseDate { get; set; }
        public string OriginCountry { get; set; }
    }
}