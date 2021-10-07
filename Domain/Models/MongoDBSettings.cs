namespace Domain.Models
{
    public class MongoDBSettings
    {
        public string DatabaseName { get; set; }
        public string MoviesCollectionName { get; set; }
        public string TVShowsCollectionName { get; set; }
        public string MovieDetailsCollectionName { get; set; }
        public string TVShowDetailsCollectionName { get; set; }
    }
}
