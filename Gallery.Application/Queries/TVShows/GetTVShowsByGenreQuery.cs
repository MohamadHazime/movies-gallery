namespace Gallery.Application.Queries
{
    public class GetTVShowsByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
