namespace Enquiry.Application.Queries
{
    public class GetTopRatedMoviesByGenreQuery : GetShowsListQuery
    {
        public int GenreId { get; set; }
    }
}
