using Microsoft.AspNetCore.Mvc;
using LMS_project_5.Models;
using LMS_project_5.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_project_5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderController(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        // GET: Reader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reader>>> GetAllReaders()
        {
            var readers = await _readerRepository.GetAllReadersAsync();
            return Ok(readers);
        }

        // GET: Reader/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Reader>> GetReaderById(int id)
        {
            var reader = await _readerRepository.GetReaderByIdAsync(id);
            if (reader != null)
            {
                return Ok(reader);
            }
            return NotFound($"Reader with ID {id} not found.");
        }

        // POST: Reader
        [HttpPost]
        public async Task<ActionResult<Reader>> CreateReader([FromBody] Reader reader)
        {
            var newReader = await _readerRepository.AddReaderAsync(reader);
            return CreatedAtAction(nameof(GetReaderById), new { id = newReader.IDReader }, newReader);
        }

        // PUT: Reader/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReader(int id, [FromBody] Reader reader)
        {
            if (id != reader.IDReader)
            {
                return BadRequest("Reader ID mismatch");
            }

            var updatedReader = await _readerRepository.UpdateReaderAsync(reader);
            if (updatedReader == null)
            {
                return NotFound($"Reader with ID {id} not found.");
            }

            return NoContent(); // Indicating successful update without returning data
        }

        // DELETE: Reader/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReader(int id)
        {
            var existingReader = await _readerRepository.GetReaderByIdAsync(id);
            if (existingReader == null)
            {
                return NotFound($"Reader with ID {id} not found.");
            }

            await _readerRepository.DeleteReaderAsync(id);
            return NoContent(); // Indicating successful deletion
        }
    }
}
