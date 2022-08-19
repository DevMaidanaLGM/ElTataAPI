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
    public class DetallesPedidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetallesPedidosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DetallesPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesPedido>>> GetDetallesPedido()
        {
          if (_context.Detalles_Pedidos == null)
          {
              return NotFound();
          }
            return await _context.Detalles_Pedidos.ToListAsync();
        }

        // GET: api/DetallesPedidos/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesPedido>> GetDetallePedido(int id)
        {
          if (_context.Detalles_Pedidos == null)
          {
              return NotFound();
          }
            var detallesPedido = await _context.Detalles_Pedidos.FindAsync(id);
            
            if (detallesPedido == null)
            {
                return NotFound();
            }

            return detallesPedido;
        }

        [HttpGet("lista/{id}")]
        public async Task<ActionResult<IEnumerable<DetallesPedido>>> GetDetallesPedido(int id)
        {
            if (_context.Detalles_Pedidos == null)
            {
                return NotFound();
            }
            var detallesPedido = await _context.Detalles_Pedidos.Where(det => det.Fk_Id_Pedido == id).ToListAsync();
            if (detallesPedido == null)
            {
                return NotFound();
            }

            return detallesPedido;
        }


        // PUT: api/DetallesPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesPedido(int id, DetallesPedido detallesPedido)
        {
            if (id != detallesPedido.Id_Detalle_Pedido)
            {
                return BadRequest();
            }

            _context.Entry(detallesPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesPedidoExists(id))
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

        // POST: api/DetallesPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesPedido>> PostDetallesPedido(DetallesPedido detallesPedido)
        {
          if (_context.Detalles_Pedidos == null)
          {
              return Problem("Entity set 'AppDbContext.DetallesPedido'  is null.");
          }
            _context.Detalles_Pedidos.Add(detallesPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesPedido", new { id = detallesPedido.Id_Detalle_Pedido }, detallesPedido);
        }

        // DELETE: api/DetallesPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesPedido(int id)
        {
            if (_context.Detalles_Pedidos == null)
            {
                return NotFound();
            }
            var detallesPedido = await _context.Detalles_Pedidos.FindAsync(id);
            if (detallesPedido == null)
            {
                return NotFound();
            }

            _context.Detalles_Pedidos.Remove(detallesPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesPedidoExists(int id)
        {
            return (_context.Detalles_Pedidos?.Any(e => e.Id_Detalle_Pedido == id)).GetValueOrDefault();
        }
    }
}
