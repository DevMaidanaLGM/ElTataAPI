using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class Sandwich
    {
        [Key]
        public int Id_Sandwich { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
