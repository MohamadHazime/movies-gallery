namespace Enquiry.Application.Queries
{
    public class GetTopRatedTVShowsByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
