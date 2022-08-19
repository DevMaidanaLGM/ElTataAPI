using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models.Views
{
    public class Vw_Usuarios
    {
        [Key]

        public int Id_Usuario { get; set; }

        public string? Username { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NroTelefono { get; set; }
        public string? FechaAlta { get; set; }
        public string? Rol_Descripcion { get; set; }
    }
}
