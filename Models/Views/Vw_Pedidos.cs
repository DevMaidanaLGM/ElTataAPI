using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models.Views
{
    public class Vw_Pedidos
    {
        [Key]
        public int Id_Pedido { get; set; }

        public int Id_Usuario { get; set; }

        public string? Usuario_Nombre { get; set; }

        public string? Usuario_Apellido { get; set; }
        //public int Id_Cliente { get; set; }

        public string? FechaCreacion { get; set; }
        public string? FechaLimite { get; set; }
        public string? FechaEntrega { get; set; }
        public string? HoraLimite { get; set; }
        public string? Direccion { get; set; }
        public string? Estado { get; set; }

    }
}
