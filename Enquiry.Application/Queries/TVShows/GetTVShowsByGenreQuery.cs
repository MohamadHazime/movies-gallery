namespace Enquiry.Application.Queries
{
    public class GetTVShowsByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
