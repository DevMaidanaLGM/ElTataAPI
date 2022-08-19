using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElTataAPI.Context;
using ElTataAPI.Models;

namespace ElTataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SandwichesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SandwichesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sandwiches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sandwich>>> GetSandwich()
        {
          if (_context.Sandwiches == null)
          {
              return NotFound();
          }
            return await _context.Sandwiches.ToListAsync();
        }

        // GET: api/Sandwiches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sandwich>> GetSandwich(int id)
        {
          if (_context.Sandwiches == null)
          {
              return NotFound();
          }
            var sandwich = await _context.Sandwiches.FindAsync(id);

            if (sandwich == null)
            {
                return NotFound();
            }

            return sandwich;
        }

        // PUT: api/Sandwiches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSandwich(int id, Sandwich sandwich)
        {
            if (id != sandwich.Id_Sandwich)
            {
                return BadRequest();
            }

            _context.Entry(sandwich).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SandwichExists(id))
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

        // POST: api/Sandwiches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sandwich>> PostSandwich(Sandwich sandwich)
        {
          if (_context.Sandwiches == null)
          {
              return Problem("Entity set 'AppDbContext.Sandwich'  is null.");
          }
            _context.Sandwiches.Add(sandwich);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSandwich", new { id = sandwich.Id_Sandwich }, sandwich);
        }

        // DELETE: api/Sandwiches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSandwich(int id)
        {
            if (_context.Sandwiches == null)
            {
                return NotFound();
            }
            var sandwich = await _context.Sandwiches.FindAsync(id);
            if (sandwich == null)
            {
                return NotFound();
            }

            _context.Sandwiches.Remove(sandwich);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SandwichExists(int id)
        {
            return (_context.Sandwiches?.Any(e => e.Id_Sandwich == id)).GetValueOrDefault();
        }
    }
}
