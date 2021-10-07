namespace Enquiry.Application.Queries
{
    public class GetMoviesByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
