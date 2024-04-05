using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using LMS_project_5.Data;

namespace LMS_project_5.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int idBook)
        {
            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.IDBook == idBook);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var bookToUpdate = await _context.Books.FirstOrDefaultAsync(b => b.IDBook == book.IDBook);
            if (bookToUpdate != null)
            {
                _context.Entry(bookToUpdate).CurrentValues.SetValues(book);
                await _context.SaveChangesAsync();
            }
            return bookToUpdate;
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
