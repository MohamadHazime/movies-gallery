using Common;
using Gallery.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gallery.Infrastructure.Repositories
{
    public class MongoMoviesRepository : IMongoShowsRepository<MovieToAdd>
    {
        private const string moviesCollectionName = "movies";
        private readonly IMongoCollection<MovieToAdd> _movies;

        public MongoMoviesRepository(IMongoClient client)
        {
            _movies = client.GetDatabase(DatabaseNames.MoviesDB)
                .GetCollection<MovieToAdd>(moviesCollectionName);
        }

        public async Task<MovieToAdd> AddAsync(MovieToAdd item)
        {
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = ObjectId.GenerateNewId().ToString();
            }

            item.ReleaseDate = string.Format("{0:dd-MM-yyyy}", DateTimeOffset.UtcNow);

            await _movies.InsertOneAsync(item);

            return item;
        }

        public async Task<List<MovieToAdd>> AddAllAsync(List<MovieToAdd> list)
        {
            try
            {
                await _movies.InsertManyAsync(list, options: new InsertManyOptions
                {
                    IsOrdered = false
                });
            }
            catch (MongoBulkWriteException ex)
            {
                Console.WriteLine(ex.ToString());
                return list;
            }

            return list;
        }
    }
}
