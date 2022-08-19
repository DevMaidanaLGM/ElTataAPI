using ElTataAPI.Context;
using ElTataAPI.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElTataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ViewsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<Vw_Usuarios>>> GetUsuarios()
        {
            if (_context.vw_Usuarios == null)
            {
                return NotFound();
            }
            return await _context.vw_Usuarios.ToListAsync();
        }

        [HttpGet("pedidos")]
        public async Task<ActionResult<IEnumerable<Vw_Pedidos>>> GetPedidos()
        {
            if (_context.vw_Pedidos == null)
            {
                return NotFound();
            }
            return await _context.vw_Pedidos.ToListAsync();
        }
        [HttpGet("pedidosPendientes")]
        public async Task<ActionResult<IEnumerable<Vw_Pedidos>>> GetPedidosPendientes()
        {
            if (_context.vw_Pedidos == null)
            {
                return NotFound();
            }
            var pedidosPendientes = await _context.vw_Pedidos.Where(ped => ped.Estado.Equals("PENDIENTE")).ToListAsync();
            if (pedidosPendientes == null)
            {
                return NotFound();
            }
            return await _context.vw_Pedidos.ToListAsync();
        }



        [HttpGet("recetas")]
        public async Task<ActionResult<IEnumerable<Vw_Recetas>>> GetRecetas()
        {
            if (_context.vw_Recetas == null)
            {
                return NotFound();
            }
            return await _context.vw_Recetas.ToListAsync();
        }


        [HttpGet("ingredientes")]
        public async Task<ActionResult<IEnumerable<Vw_Ingredientes>>> GetIngredientes()
        {
            if (_context.vw_Ingredientes == null)
            {
                return NotFound();
            }
            return await _context.vw_Ingredientes.ToListAsync();
        }
        [HttpGet("ingredientesRecetas/lista/{id}")]
        public async Task<ActionResult<IEnumerable<Vw_Ingredientes_Recetas>>> GetIngredientesRecetaLista(int id)
        {
            if (_context.vw_Ingredientes_Recetas == null)
            {
                return NotFound();
            }
            var ingredientesReceta = await _context.vw_Ingredientes_Recetas.Where(det => det.Id_Receta == id).ToListAsync();
            if (ingredientesReceta == null)
            {
                return NotFound();
            }

            return ingredientesReceta;
        }


        [HttpGet("detallesPedidos")]
        public async Task<ActionResult<IEnumerable<Vw_Detalles_Pedidos>>> GetDetallesPedidos()
        {
            if (_context.vw_Detalles_Pedidos == null)
            {
                return NotFound();
            }
            return await _context.vw_Detalles_Pedidos.ToListAsync();
        }
        [HttpGet("detallesPedidos/lista/{id}")]
        public async Task<ActionResult<IEnumerable<Vw_Detalles_Pedidos>>> GetDetallesPedidosLista(int id)
        {
            if (_context.vw_Detalles_Pedidos == null)
            {
                return NotFound();
            }
            var detallesPedido = await _context.vw_Detalles_Pedidos.Where(det => det.Fk_Id_Pedido == id).ToListAsync();
            if (detallesPedido == null)
            {
                return NotFound();
            }

            return detallesPedido;
        }

        /**
        [HttpGet("pedidos")]
        public async Task<ActionResult<IEnumerable<Vw_Usuarios>>> GetPedidos()
        {
            if (_context.vw_Usuarios == null)
            {
                return NotFound();
            }
            return await _context.vw_Usuarios.ToListAsync();
        }
        [HttpGet("ingredientes")]
        public async Task<ActionResult<IEnumerable<Vw_Usuarios>>> getIngredientes()
        {
            if (_context.vw_Usuarios == null)
            {
                return NotFound();
            }
            return await _context.vw_Usuarios.ToListAsync();
        }
        */
    }
}
