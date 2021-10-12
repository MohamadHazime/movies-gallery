using Gallery.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domain.AggregatesModel.MovieAggregate
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> AddAsync(Movie movie);
        Task<List<Movie>> AddAllAsync(List<Movie> movieList);
    }
}
