using Core.Dtos;
using Core.Models;
using Enquiry.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesGallery.Core.Services
{
    public class MongoTVShowsRepository : IMongoShowsRepository<TVShowDetailsDTO>
    {
        private readonly IMongoCollection<ShowDTO> _tvShows;
        private readonly IMongoCollection<ShowDetailsDTO> _tvShowDetails;

        public MongoTVShowsRepository(IOptions<MongoDBSettings> moviesDbSettings, IMongoClient client)
        {
            _tvShows = client.GetDatabase(moviesDbSettings.Value.DatabaseName)
                .GetCollection<ShowDTO>(moviesDbSettings.Value.TVShowsCollectionName);
            _tvShowDetails = client.GetDatabase(moviesDbSettings.Value.DatabaseName)
                .GetCollection<ShowDetailsDTO>(moviesDbSettings.Value.TVShowDetailsCollectionName);
        }

        public async Task<List<ShowDTO>> AddAllAsync(List<ShowDTO> list)
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

        public async Task<TVShowDetailsDTO> AddDetailsAsync(TVShowDetailsDTO showDetails)
        {
            var movie = await _tvShowDetails.FindOneAndReplaceAsync(t => t.Id == showDetails.Id, showDetails);

            if (movie == null)
            {
                await _tvShowDetails.InsertOneAsync(showDetails);
            }

            return showDetails;
        }
    }
}
