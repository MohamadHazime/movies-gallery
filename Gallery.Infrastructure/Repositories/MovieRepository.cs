using Common;
using Gallery.Domain.AggregatesModel.MovieAggregate;
using Gallery.Domain.SeedWork;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private const string moviesCollectionName = "movies";
        private readonly IMongoCollection<Movie> _movies;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public MovieRepository(IMongoClient client)
        {
            _movies = client.GetDatabase(DatabaseNames.MoviesDB)
               .GetCollection<Movie>(moviesCollectionName);
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            if (string.IsNullOrEmpty(movie.Id))
            {
                movie.Id = ObjectId.GenerateNewId().ToString();
            }

            if (string.IsNullOrEmpty(movie.ReleaseDate))
            {
                movie.ReleaseDate = string.Format("{0:dd-MM-yyyy}", DateTimeOffset.UtcNow);
            }

            await _movies.InsertOneAsync(movie);

            return movie;
        }

        public async Task<List<Movie>> AddAllAsync(List<Movie> movieList)
        {
            try
            {
                await _movies.InsertManyAsync(movieList, options: new InsertManyOptions
                {
                    IsOrdered = false
                });
            }
            catch (MongoBulkWriteException ex)
            {
                Console.WriteLine(ex.ToString());
                return movieList;
            }

            return movieList;
        }
    }
}
