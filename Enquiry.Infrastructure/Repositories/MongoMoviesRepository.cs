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
    public class MongoMoviesRepository : IMongoShowsRepository<MovieDetailsDTO>
    {
        private readonly IMongoCollection<ShowDTO> _movies;
        private readonly IMongoCollection<ShowDetailsDTO> _movieDetails;

        public MongoMoviesRepository(IOptions<MongoDBSettings> moviesDbSettings, IMongoClient client)
        {
            _movies = client.GetDatabase(moviesDbSettings.Value.DatabaseName)
                .GetCollection<ShowDTO>(moviesDbSettings.Value.MoviesCollectionName);
            _movieDetails = client.GetDatabase(moviesDbSettings.Value.DatabaseName)
                .GetCollection<ShowDetailsDTO>(moviesDbSettings.Value.MovieDetailsCollectionName);
        }

        public async Task<List<ShowDTO>> AddAllAsync(List<ShowDTO> list)
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

        public async Task<MovieDetailsDTO> AddDetailsAsync(MovieDetailsDTO showDetails)
        {
            var movie = await _movieDetails.FindOneAndReplaceAsync(m => m.Id == showDetails.Id, showDetails);

            if(movie == null)
            {
                await _movieDetails.InsertOneAsync(showDetails);
            }

            return showDetails;
        }
    }
}
