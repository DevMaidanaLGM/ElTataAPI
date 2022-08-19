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
    public class IngredientesRecetasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientesRecetasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/IngredientesRecetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientesReceta>>> GetIngredientes_Recetas()
        {
          if (_context.Ingredientes_Recetas == null)
          {
              return NotFound();
          }
            return await _context.Ingredientes_Recetas.ToListAsync();
        }

        // GET: api/IngredientesRecetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientesReceta>> GetIngredientesReceta(int id)
        {
          if (_context.Ingredientes_Recetas == null)
          {
              return NotFound();
          }
            var ingredientesReceta = await _context.Ingredientes_Recetas.FindAsync(id);

            if (ingredientesReceta == null)
            {
                return NotFound();
            }

            return ingredientesReceta;
        }

        // GET: api/IngredientesRecetas/lista/5

        [HttpGet("lista/{id}")]
        public async Task<ActionResult<IEnumerable<IngredientesReceta>>> GetIngredientesRecetaLista(int id)
        {
            if (_context.Ingredientes_Recetas == null)
            {
                return NotFound();
            }
            var ingredientesReceta= await _context.Ingredientes_Recetas.Where(det => det.Fk_Id_Receta == id).ToListAsync();
            if (ingredientesReceta == null)
            {
                return NotFound();
            }

            return ingredientesReceta;
        }
        // PUT: api/IngredientesRecetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientesReceta(int id, IngredientesReceta ingredientesReceta)
        {
            if (id != ingredientesReceta.Id_Ingrediente_Receta)
            {
                return BadRequest();
            }

            _context.Entry(ingredientesReceta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientesRecetaExists(id))
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

        // POST: api/IngredientesRecetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientesReceta>> PostIngredientesReceta(IngredientesReceta ingredientesReceta)
        {
          if (_context.Ingredientes_Recetas == null)
          {
              return Problem("Entity set 'AppDbContext.Ingredientes_Recetas'  is null.");
          }
            _context.Ingredientes_Recetas.Add(ingredientesReceta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientesReceta", new { id = ingredientesReceta.Id_Ingrediente_Receta }, ingredientesReceta);
        }

        // DELETE: api/IngredientesRecetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientesReceta(int id)
        {
            if (_context.Ingredientes_Recetas == null)
            {
                return NotFound();
            }
            var ingredientesReceta = await _context.Ingredientes_Recetas.FindAsync(id);
            if (ingredientesReceta == null)
            {
                return NotFound();
            }

            _context.Ingredientes_Recetas.Remove(ingredientesReceta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientesRecetaExists(int id)
        {
            return (_context.Ingredientes_Recetas?.Any(e => e.Id_Ingrediente_Receta == id)).GetValueOrDefault();
        }
    }
}
