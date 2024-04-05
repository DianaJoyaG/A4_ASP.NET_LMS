using LMS_project_5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_project_5.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<IEnumerable<Borrowing>> GetAllBorrowingsAsync();
        Task<Borrowing> GetBorrowingByIdAsync(int borrowingId);
        Task<Borrowing> AddBorrowingAsync(Borrowing borrowing);
        Task<Borrowing> UpdateBorrowingAsync(Borrowing borrowing);
        Task DeleteBorrowingAsync(int borrowingId);
    }
}
