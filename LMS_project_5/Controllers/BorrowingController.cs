using Microsoft.AspNetCore.Mvc;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_project_5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingRepository _borrowingRepository;

        public BorrowingController(IBorrowingRepository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        // GET: Borrowing
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrowing>>> GetAllBorrowings()
        {
            var borrowings = await _borrowingRepository.GetAllBorrowingsAsync();
            return Ok(borrowings);
        }

        // GET: Borrowing/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrowing>> GetBorrowingById(int id)
        {
            var borrowing = await _borrowingRepository.GetBorrowingByIdAsync(id);
            if (borrowing != null)
            {
                return Ok(borrowing);
            }
            return NotFound();
        }

        // POST: Borrowing
        [HttpPost]
        public async Task<ActionResult<Borrowing>> CreateBorrowing([FromBody] Borrowing borrowing)
        {
            var createdBorrowing = await _borrowingRepository.AddBorrowingAsync(borrowing);
            return CreatedAtAction(nameof(GetBorrowingById), new { id = createdBorrowing.IDBorrowing }, createdBorrowing);
        }

        // PUT: Borrowing/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Borrowing>> UpdateBorrowing(int id, [FromBody] Borrowing borrowing)
        {
            if (id != borrowing.IDBorrowing)
            {
                return BadRequest();
            }

            var updatedBorrowing = await _borrowingRepository.UpdateBorrowingAsync(borrowing);
            if (updatedBorrowing == null)
            {
                return NotFound();
            }

            return Ok(updatedBorrowing);
        }

        // DELETE: Borrowing/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowing(int id)
        {
            await _borrowingRepository.DeleteBorrowingAsync(id);
            return NoContent();
        }
    }
}
