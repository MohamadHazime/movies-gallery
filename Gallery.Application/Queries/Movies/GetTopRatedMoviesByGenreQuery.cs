namespace Gallery.Application.Queries
{
    public class GetTopRatedMoviesByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
