using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_info_seeker_api.Model;
using stock_info_seeker_api.Services;

namespace stock_info_seeker_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ProjectContext _context;
        private IUserService _userService;

        public WordsController(ProjectContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


        [HttpPost("authenticate")]
        //[HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


        // GET: api/Words
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeekFor>>> GetseekFor()
        {
            return await _context.seekFor.ToListAsync();
        }

        // GET: api/Words/5
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SeekFor>> PostSeekFor(SeekFor seekFor)
        {
            _context.seekFor.Add(seekFor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeekFor", new { id = seekFor.Id }, seekFor);
        }

        // DELETE: api/Words/5
        [Authorize]
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
