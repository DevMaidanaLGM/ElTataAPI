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
    public class TipoIngredientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoIngredientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoIngredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIngrediente>>> GetTipo_Ingredientes()
        {
          if (_context.Tipo_Ingredientes == null)
          {
              return NotFound();
          }
            return await _context.Tipo_Ingredientes.ToListAsync();
        }

        // GET: api/TipoIngredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIngrediente>> GetTipoIngrediente(int id)
        {
          if (_context.Tipo_Ingredientes == null)
          {
              return NotFound();
          }
            var tipoIngrediente = await _context.Tipo_Ingredientes.FindAsync(id);

            if (tipoIngrediente == null)
            {
                return NotFound();
            }

            return tipoIngrediente;
        }

        // PUT: api/TipoIngredientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIngrediente(int id, TipoIngrediente tipoIngrediente)
        {
            if (id != tipoIngrediente.Id_Tipo_Ingrediente)
            {
                return BadRequest();
            }

            _context.Entry(tipoIngrediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIngredienteExists(id))
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

        // POST: api/TipoIngredientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoIngrediente>> PostTipoIngrediente(TipoIngrediente tipoIngrediente)
        {
          if (_context.Tipo_Ingredientes == null)
          {
              return Problem("Entity set 'AppDbContext.Tipo_Ingredientes'  is null.");
          }
            _context.Tipo_Ingredientes.Add(tipoIngrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoIngrediente", new { id = tipoIngrediente.Id_Tipo_Ingrediente }, tipoIngrediente);
        }

        // DELETE: api/TipoIngredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoIngrediente(int id)
        {
            if (_context.Tipo_Ingredientes == null)
            {
                return NotFound();
            }
            var tipoIngrediente = await _context.Tipo_Ingredientes.FindAsync(id);
            if (tipoIngrediente == null)
            {
                return NotFound();
            }

            _context.Tipo_Ingredientes.Remove(tipoIngrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoIngredienteExists(int id)
        {
            return (_context.Tipo_Ingredientes?.Any(e => e.Id_Tipo_Ingrediente == id)).GetValueOrDefault();
        }
    }
}
