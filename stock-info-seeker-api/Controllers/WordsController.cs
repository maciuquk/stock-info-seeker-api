using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_info_seeker_api.Model;

namespace stock_info_seeker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public WordsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeekFor>>> GetseekFor()
        {
            return await _context.seekFor.ToListAsync();
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeekFor>> GetSeekFor(int id)
        {
            var seekFor = await _context.seekFor.FindAsync(id);

            if (seekFor == null)
            {
                return NotFound();
            }

            return seekFor;
        }

        // PUT: api/Words/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeekFor(int id, SeekFor seekFor)
        {
            if (id != seekFor.Id)
            {
                return BadRequest();
            }

            _context.Entry(seekFor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeekForExists(id))
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

        // POST: api/Words
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeekFor>> PostSeekFor(SeekFor seekFor)
        {
            _context.seekFor.Add(seekFor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeekFor", new { id = seekFor.Id }, seekFor);
        }

        // DELETE: api/Words/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeekFor(int id)
        {
            var seekFor = await _context.seekFor.FindAsync(id);
            if (seekFor == null)
            {
                return NotFound();
            }

            _context.seekFor.Remove(seekFor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeekForExists(int id)
        {
            return _context.seekFor.Any(e => e.Id == id);
        }
    }
}
