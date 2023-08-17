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
    public class SanbongsController : ControllerBase
    {
        private readonly booksanbongContext _context;

        public SanbongsController(booksanbongContext context)
        {
            _context = context;
        }

        // GET: api/Sanbongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sanbong>>> GetSanbongs()
        {
            return await _context.Sanbongs.ToListAsync();
        }

        // GET: api/Sanbongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sanbong>> GetSanbong(int id)
        {
            var sanbong = await _context.Sanbongs.FindAsync(id);

            if (sanbong == null)
            {
                return NotFound();
            }

            return sanbong;
        }

        // PUT: api/Sanbongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanbong(int id, Sanbong sanbong)
        {
            if (id != sanbong.Id)
            {
                return BadRequest();
            }

            _context.Entry(sanbong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanbongExists(id))
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

        // POST: api/Sanbongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sanbong>> PostSanbong(Sanbong sanbong)
        {
            _context.Sanbongs.Add(sanbong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanbong", new { id = sanbong.Id }, sanbong);
        }

        // DELETE: api/Sanbongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanbong(int id)
        {
            var sanbong = await _context.Sanbongs.FindAsync(id);
            if (sanbong == null)
            {
                return NotFound();
            }

            _context.Sanbongs.Remove(sanbong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanbongExists(int id)
        {
            return _context.Sanbongs.Any(e => e.Id == id);
        }
    }
}
