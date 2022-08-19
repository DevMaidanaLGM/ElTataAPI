using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class Venta
    {
        [Key]
        public int Id_Venta { get; set; }
        public int Fk_Id_Pedido { get; set; }
        public string? Fecha { get; set; }
        public int Importe { get; set; }
    }
}
