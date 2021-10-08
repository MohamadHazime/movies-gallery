using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gallery.Infrastructure.Repositories
{
    public interface IMongoShowsRepository<T>
    {
        Task<T> AddAsync(T item);
        Task<List<T>> AddAllAsync(List<T> list);
    }
}
