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
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonContext _context;

        public PersonsController(PersonContext context)
        {
            _context = context;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persons>>> GetPeresons()
        {
            return await _context.Peresons.ToListAsync();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persons>> GetPersons(int id)
        {
            var persons = await _context.Peresons.FindAsync(id);

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }

        // GET: api/Persons/GetManagerActiveTimeoffs/5
        //[HttpGet("apimethod/{id}")]
        //[HttpGet("[controller]/[action]/{id}")]
        //public async Task<ActionResult<Persons>> GetManagerActiveTimeoffs(int id)
        //{
        //    var persons = await _context.Peresons.FindAsync(id);

        //    if (persons == null)
        //    {
        //        return NotFound();
        //    }

        //    return persons;
        //}

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersons(int id, Persons persons)
        {
            if (id != persons.Id)
            {
                return BadRequest();
            }

            _context.Entry(persons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonsExists(id))
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

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persons>> PostPersons(Persons persons)
        {
            _context.Peresons.Add(persons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersons", new { id = persons.Id }, persons);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersons(int id)
        {
            var persons = await _context.Peresons.FindAsync(id);
            if (persons == null)
            {
                return NotFound();
            }

            _context.Peresons.Remove(persons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonsExists(int id)
        {
            return _context.Peresons.Any(e => e.Id == id);
        }
    }
}
