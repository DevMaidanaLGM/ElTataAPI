using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class Pedido
    {
        [Key]
        public int Id_Pedido { get; set; }
        public int Fk_Id_Usuario { get; set; }
        public int Fk_Id_Cliente { get; set; }
        public string? FechaCreacion { get; set; }
        public string? FechaLimite { get; set; }
        public string? FechaEntrega { get; set; }
        public string? HoraLimite { get; set; }
        public string? Direccion { get; set; }
        public string? Estado { get; set; }


    }
}
