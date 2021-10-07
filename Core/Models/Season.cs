namespace Core.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string AirDate { get; set; }
        public int EpisodeCount { get; set; }
        public string PosterPath { get; set; }
        public int SeasonNumber { get; set; }
    }
}