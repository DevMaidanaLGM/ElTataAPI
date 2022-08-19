using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class DetallesPedido
    {
        [Key]
        public int Id_Detalle_Pedido { get; set; }
        public int Fk_Id_Pedido { get; set; }
        public int Fk_Id_Receta { get; set; }
        public int Fk_Id_Sandwich { get; set; }
        public int Cantidad { get; set; }

        public int PrecioUnitario { get; set; }


    }
}
