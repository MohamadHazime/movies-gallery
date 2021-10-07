using Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enquiry.Infrastructure.Repositories
{
    public interface IMongoShowsRepository<T>
    {
        Task<List<ShowDTO>> AddAllAsync(List<ShowDTO> list);
        Task<T> AddDetailsAsync(T showDetails);
    }
}
