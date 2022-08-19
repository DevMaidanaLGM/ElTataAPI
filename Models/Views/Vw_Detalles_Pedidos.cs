using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models.Views
{
    public class Vw_Detalles_Pedidos
        
    {
        [Key]
        public int Id_Detalle_Pedido { get; set; }
        public int Detalle_Cantidad { get; set; }
        public int Detalle_PrecioUnitario { get; set; }
        public int Id_Sandwich { get; set; }
        public int Id_Receta { get; set; }
        public int Fk_Id_Pedido { get; set; }
        public string? Receta_Nombre { get; set; }
        public string? Receta_Descripcion { get; set; }
        public string? Sandwich_Nombre { get; set; }
        public string? Sandwich_Descripcion { get; set; }


    }
}
