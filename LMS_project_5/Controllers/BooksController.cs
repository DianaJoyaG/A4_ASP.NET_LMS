using Microsoft.AspNetCore.Mvc;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_project_5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        // GET: Book/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        // POST: Book
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            var createdBook = await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.IDBook }, createdBook);
        }

        // PUT: Book/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.IDBook)
            {
                return BadRequest();
            }

            var updatedBook = await _bookRepository.UpdateBookAsync(book);
            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        // DELETE: Book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
