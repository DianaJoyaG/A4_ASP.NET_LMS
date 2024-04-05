using LMS_project_5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_project_5.Interfaces
{
    public interface IReaderRepository
    {
        Task<IEnumerable<Reader>> GetAllReadersAsync();
        Task<Reader> GetReaderByIdAsync(int readerId);
        Task<Reader> AddReaderAsync(Reader reader);
        Task<Reader> UpdateReaderAsync(Reader reader);
        Task DeleteReaderAsync(int readerId);
    }
}
