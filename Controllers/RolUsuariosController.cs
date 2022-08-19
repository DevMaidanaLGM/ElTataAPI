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
    public class RolUsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolUsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RolUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolUsuario>>> GetRol_Usuarios()
        {
          if (_context.Rol_Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Rol_Usuarios.ToListAsync();
        }

        // GET: api/RolUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolUsuario>> GetRolUsuario(int id)
        {
          if (_context.Rol_Usuarios == null)
          {
              return NotFound();
          }
            var rolUsuario = await _context.Rol_Usuarios.FindAsync(id);

            if (rolUsuario == null)
            {
                return NotFound();
            }

            return rolUsuario;
        }

        // PUT: api/RolUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolUsuario(int id, RolUsuario rolUsuario)
        {
            if (id != rolUsuario.Id_Rol_Usuario)
            {
                return BadRequest();
            }

            _context.Entry(rolUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolUsuarioExists(id))
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

        // POST: api/RolUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolUsuario>> PostRolUsuario(RolUsuario rolUsuario)
        {
          if (_context.Rol_Usuarios == null)
          {
              return Problem("Entity set 'AppDbContext.Rol_Usuarios'  is null.");
          }
            _context.Rol_Usuarios.Add(rolUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolUsuario", new { id = rolUsuario.Id_Rol_Usuario }, rolUsuario);
        }

        // DELETE: api/RolUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolUsuario(int id)
        {
            if (_context.Rol_Usuarios == null)
            {
                return NotFound();
            }
            var rolUsuario = await _context.Rol_Usuarios.FindAsync(id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            _context.Rol_Usuarios.Remove(rolUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolUsuarioExists(int id)
        {
            return (_context.Rol_Usuarios?.Any(e => e.Id_Rol_Usuario == id)).GetValueOrDefault();
        }
    }
}
