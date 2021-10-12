using Gallery.Domain.Events;
using Gallery.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Domain.AggregatesModel.MovieAggregate
{
    public class Movie : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public double VoteAverage { get; private set; }
        public string OriginalLanguage { get; private set; }
        public string Overview { get; private set; }
        public string PosterPath { get; private set; }
        //public IReadOnlyList<int> GenreIds { get; private set; }
        public IReadOnlyList<Genre> Genres { get; private set; }

        public Movie(
            string id,
            string title,
            double voteAverage,
            string releaseDate,
            string originalLanguage,
            string overview,
            string posterPath,
            //List<int> genreIds,
            List<Genre> genres
        )
        {
            Id = id;
            Title = title;
            VoteAverage = voteAverage;
            ReleaseDate = releaseDate;
            OriginalLanguage = originalLanguage;
            Overview = overview;
            PosterPath = posterPath;
            //GenreIds = genreIds;
            Genres = genres;

            AddGetMovieStartedDomainEvent();
        }

        private void AddGetMovieStartedDomainEvent()
        {
            var getMovieStartedDomainEvent = new GetMovieStartedDomainEvent(this);

            this.AddDomainEvent(getMovieStartedDomainEvent);
        }
    }
}
