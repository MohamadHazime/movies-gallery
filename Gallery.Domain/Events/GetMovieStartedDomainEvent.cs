using Gallery.Domain.AggregatesModel.MovieAggregate;
using MediatR;

namespace Gallery.Domain.Events
{
    public class GetMovieStartedDomainEvent : INotification
    {
        public Movie Movie { get; }

        public GetMovieStartedDomainEvent(Movie movie)
        {
            Movie = movie;
        }
    }
}
