using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using LMS_project_5.Data;

namespace LMS_project_5.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryContext _context;

        public ReaderRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Reader> GetReaderByIdAsync(int readerId)
        {
            return await _context.Readers.AsNoTracking().FirstOrDefaultAsync(r => r.IDReader == readerId);
        }

        public async Task<IEnumerable<Reader>> GetAllReadersAsync()
        {
            return await _context.Readers.AsNoTracking().ToListAsync();
        }

        public async Task<Reader> AddReaderAsync(Reader reader)
        {
            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();
            return reader;
        }

        public async Task<Reader> UpdateReaderAsync(Reader reader)
        {
            var readerToUpdate = await _context.Readers.FirstOrDefaultAsync(r => r.IDReader == reader.IDReader);
            if (readerToUpdate != null)
            {
                _context.Entry(readerToUpdate).CurrentValues.SetValues(reader);
                await _context.SaveChangesAsync();
            }
            return readerToUpdate;
        }

        public async Task DeleteReaderAsync(int readerId)
        {
            var reader = await _context.Readers.FindAsync(readerId);
            if (reader != null)
            {
                _context.Readers.Remove(reader);
                await _context.SaveChangesAsync();
            }
        }
    }
}
