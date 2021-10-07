using Gallery.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gallery.Infrastructure.Repositories
{
    public interface IMongoShowsRepository<T>
    {
        Task<List<ShowDTO>> AddAllAsync(List<ShowDTO> list);
        Task<T> AddDetailsAsync(T showDetails);
    }
}
