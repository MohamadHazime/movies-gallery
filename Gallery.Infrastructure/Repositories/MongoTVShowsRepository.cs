using Common;
using Gallery.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gallery.Infrastructure.Repositories
{
    public class MongoTVShowsRepository : IMongoShowsRepository<TVShowToAdd>
    {
        private const string tvShowsCollectionName = "tvshows";
        private readonly IMongoCollection<TVShowToAdd> _tvShows;

        public MongoTVShowsRepository(IMongoClient client)
        {
            _tvShows = client.GetDatabase(DatabaseNames.MoviesDB)
                .GetCollection<TVShowToAdd>(tvShowsCollectionName);
        }

        public async Task<TVShowToAdd> AddAsync(TVShowToAdd item)
        {
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = ObjectId.GenerateNewId().ToString();
            }

            item.ReleaseDate = string.Format("{0:dd-MM-yyyy}", DateTimeOffset.UtcNow);

            await _tvShows.InsertOneAsync(item);

            return item;
        }

        public async Task<List<TVShowToAdd>> AddAllAsync(List<TVShowToAdd> list)
        {
            try
            {
                await _tvShows.InsertManyAsync(list, options: new InsertManyOptions
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
