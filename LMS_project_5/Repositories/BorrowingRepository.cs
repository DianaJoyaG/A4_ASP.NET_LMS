using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using LMS_project_5.Data;

namespace LMS_project_5.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly LibraryContext _context;

        public BorrowingRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Borrowing>> GetAllBorrowingsAsync()
        {
            return await _context.Borrowings.AsNoTracking().ToListAsync();
        }

        public async Task<Borrowing> GetBorrowingByIdAsync(int borrowingId)
        {
            return await _context.Borrowings.AsNoTracking().FirstOrDefaultAsync(b => b.IDBorrowing == borrowingId);
        }

        public async Task<Borrowing> AddBorrowingAsync(Borrowing borrowing)
        {
            _context.Borrowings.Add(borrowing);
            await _context.SaveChangesAsync();
            return borrowing;
        }

        public async Task<Borrowing> UpdateBorrowingAsync(Borrowing borrowing)
        {
            var borrowingToUpdate = await _context.Borrowings.FirstOrDefaultAsync(b => b.IDBorrowing == borrowing.IDBorrowing);
            if (borrowingToUpdate != null)
            {
                _context.Entry(borrowingToUpdate).CurrentValues.SetValues(borrowing);
                await _context.SaveChangesAsync();
            }
            return borrowingToUpdate;
        }

        public async Task DeleteBorrowingAsync(int borrowingId)
        {
            var borrowing = await _context.Borrowings.FindAsync(borrowingId);
            if (borrowing != null)
            {
                _context.Borrowings.Remove(borrowing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
