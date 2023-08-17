using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gosport.Models;

namespace Gosport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksansController : ControllerBase
    {
        private readonly booksanbongContext _context;

        public BooksansController(booksanbongContext context)
        {
            _context = context;
        }

        // GET: api/Booksans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booksan>>> GetBooksans()
        {
            return await _context.Booksans.ToListAsync();
        }

        // GET: api/Booksans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booksan>> GetBooksan(int id)
        {
            var booksan = await _context.Booksans.FindAsync(id);

            if (booksan == null)
            {
                return NotFound();
            }

            return booksan;
        }

        // PUT: api/Booksans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooksan(int id, Booksan booksan)
        {
            if (id != booksan.Id)
            {
                return BadRequest();
            }

            _context.Entry(booksan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Booksans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booksan>> PostBooksan(Booksan booksan)
        {
            _context.Booksans.Add(booksan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooksan", new { id = booksan.Id }, booksan);
        }

        // DELETE: api/Booksans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooksan(int id)
        {
            var booksan = await _context.Booksans.FindAsync(id);
            if (booksan == null)
            {
                return NotFound();
            }

            _context.Booksans.Remove(booksan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksanExists(int id)
        {
            return _context.Booksans.Any(e => e.Id == id);
        }
    }
}
