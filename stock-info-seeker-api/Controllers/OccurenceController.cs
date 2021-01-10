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
    [Route("[controller]")]
    [ApiController]
    public class OccurenceController : ControllerBase
    {
        private readonly ProjectContext _context;

        public OccurenceController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Occurence
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Occurence>>> Getoccurence()
        {
            return await _context.occurence.ToListAsync();
        }

        // GET: Occurence/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Occurence>> GetOccurence(int id)
        {
            var occurence = await _context.occurence.FindAsync(id);

            if (occurence == null)
            {
                return NotFound();
            }

            return occurence;
        }

        // PUT: Occurence/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccurence(int id, Occurence occurence)
        {
            if (id != occurence.Id)
            {
                return BadRequest();
            }

            _context.Entry(occurence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OccurenceExists(id))
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

        // POST: Occurence
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Occurence>> PostOccurence(Occurence occurence)
        {
            _context.occurence.Add(occurence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOccurence", new { id = occurence.Id }, occurence);
        }

        // DELETE: Occurence/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccurence(int id)
        {
            var occurence = await _context.occurence.FindAsync(id);
            if (occurence == null)
            {
                return NotFound();
            }

            _context.occurence.Remove(occurence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OccurenceExists(int id)
        {
            return _context.occurence.Any(e => e.Id == id);
        }
    }
}
