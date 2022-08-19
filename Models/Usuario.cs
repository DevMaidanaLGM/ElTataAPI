using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class Usuario
    {
        [Key]

        public int Id_Usuario { get; set; }

        public int Fk_Id_Rol_Usuario { get;set;}
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NroTelefono { get; set; }
        public string? FechaAlta { get; set; }
        public string? FechaBaja { get; set; }
        public string? Estado { get; set; }


        
    }
}
