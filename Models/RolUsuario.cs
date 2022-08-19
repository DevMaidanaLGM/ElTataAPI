using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class RolUsuario
    {
        [Key]
        public int Id_Rol_Usuario { get; set; }

        public string? Etiqueta { get; set; }
        public string? Descripcion { get; set; }
    }
}
