namespace Gallery.Application.Queries
{
    public class GetTopRatedTVShowsByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
