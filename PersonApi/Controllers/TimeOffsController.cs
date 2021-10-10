using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonApi.Models;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeOffsController : ControllerBase
    {
        private readonly PersonContext _context;

        public TimeOffsController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/TimeOffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeOffs>>> GetTimeOffs()
        {
            return await _context.TimeOffs.ToListAsync();
        }

        // GET: api/TimeOffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeOffs>> GetTimeOffs(int id)
        {
            var timeOffs = await _context.TimeOffs.FindAsync(id);

            if (timeOffs == null)
            {
                return NotFound();
            }

            return timeOffs;
        }

        // PUT: api/TimeOffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeOffs(int id, TimeOffs timeOffs)
        {
            if (id != timeOffs.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeOffs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeOffsExists(id))
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

        // POST: api/TimeOffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeOffs>> PostTimeOffs(TimeOffs timeOffs)
        {
            _context.TimeOffs.Add(timeOffs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeOffs", new { id = timeOffs.Id }, timeOffs);
        }

        // DELETE: api/TimeOffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeOffs(int id)
        {
            var timeOffs = await _context.TimeOffs.FindAsync(id);
            if (timeOffs == null)
            {
                return NotFound();
            }

            _context.TimeOffs.Remove(timeOffs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeOffsExists(int id)
        {
            return _context.TimeOffs.Any(e => e.Id == id);
        }
    }
}
