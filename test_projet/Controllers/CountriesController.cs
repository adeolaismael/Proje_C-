using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_projet.Data;
using test_projet.Models;

namespace test_projet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly test_projetContext _context;

        public CountriesController(test_projetContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countrie>>> GetCountrie()
        {
          if (_context.Countrie == null)
          {
              return NotFound();
          }
            return await _context.Countrie.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countrie>> GetCountrie(int id)
        {
          if (_context.Countrie == null)
          {
              return NotFound();
          }
            var countrie = await _context.Countrie.FindAsync(id);

            if (countrie == null)
            {
                return NotFound();
            }

            return countrie;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountrie(int id, Countrie countrie)
        {
            if (id != countrie.Id)
            {
                return BadRequest();
            }

            _context.Entry(countrie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountrieExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Countrie>> PostCountrie(Countrie countrie)
        {
          if (_context.Countrie == null)
          {
              return Problem("Entity set 'test_projetContext.Countrie'  is null.");
          }
            _context.Countrie.Add(countrie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountrie", new { id = countrie.Id }, countrie);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountrie(int id)
        {
            if (_context.Countrie == null)
            {
                return NotFound();
            }
            var countrie = await _context.Countrie.FindAsync(id);
            if (countrie == null)
            {
                return NotFound();
            }

            _context.Countrie.Remove(countrie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountrieExists(int id)
        {
            return (_context.Countrie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
