using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models.Views
{
    public class Vw_Ingredientes
    {
        [Key]
        public int Id_Ingrediente { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo_Descripcion { get; set; }
        public int Cantidad { get; set; }
    }
}
