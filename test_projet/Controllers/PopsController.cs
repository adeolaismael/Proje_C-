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
    public class PopsController : ControllerBase
    {
        private readonly test_projetContext _context;

        public PopsController(test_projetContext context)
        {
            _context = context;
        }

        // GET: api/Pops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pop>>> GetPop()
        {
          if (_context.Pop == null)
          {
              return NotFound();
          }
            return await _context.Pop.ToListAsync();
        }

        // GET: api/Pops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pop>> GetPop(int id)
        {
          if (_context.Pop == null)
          {
              return NotFound();
          }
            var pop = await _context.Pop.FindAsync(id);

            if (pop == null)
            {
                return NotFound();
            }

            return pop;
        }

        // PUT: api/Pops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPop(int id, Pop pop)
        {
            if (id != pop.Id)
            {
                return BadRequest();
            }

            _context.Entry(pop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PopExists(id))
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

        // POST: api/Pops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pop>> PostPop(Pop pop)
        {
          if (_context.Pop == null)
          {
              return Problem("Entity set 'test_projetContext.Pop'  is null.");
          }
            _context.Pop.Add(pop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPop", new { id = pop.Id }, pop);
        }

        // DELETE: api/Pops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePop(int id)
        {
            if (_context.Pop == null)
            {
                return NotFound();
            }
            var pop = await _context.Pop.FindAsync(id);
            if (pop == null)
            {
                return NotFound();
            }

            _context.Pop.Remove(pop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PopExists(int id)
        {
            return (_context.Pop?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
