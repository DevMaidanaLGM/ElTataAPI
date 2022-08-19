using ElTataAPI.Models;
using ElTataAPI.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace ElTataAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolUsuario> Rol_Usuarios { get; set; }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<TipoIngrediente> Tipo_Ingredientes { get; set; }
        public DbSet<ElTataAPI.Models.Sandwich>? Sandwiches { get; set; }
        public DbSet<ElTataAPI.Models.Receta>? Recetas { get; set; }

        public DbSet<IngredientesReceta> Ingredientes_Recetas { get; set; }

        public DbSet<ElTataAPI.Models.Pedido>? Pedidos { get; set; }

        public DbSet<ElTataAPI.Models.Venta>? Ventas { get; set; }

        public DbSet<ElTataAPI.Models.DetallesPedido>? Detalles_Pedidos { get; set; }


        
        //Vistas
        public DbSet<Vw_Usuarios> vw_Usuarios { get; set; }
        public DbSet<Vw_Ingredientes>vw_Ingredientes { get; set; }
        public DbSet<Vw_Recetas>vw_Recetas { get; set; }
        public DbSet<Vw_Ingredientes_Recetas>vw_Ingredientes_Recetas { get; set; }
        public DbSet<Vw_Pedidos>vw_Pedidos { get; set; }
        public DbSet<Vw_Precios>vw_Precios { get; set; }
        public DbSet<Vw_Detalles_Pedidos> vw_Detalles_Pedidos { get; set; }
    }
}
