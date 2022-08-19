using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class TipoIngrediente
    {
        [Key]
        public int Id_Tipo_Ingrediente { get; set; }
        public string? Etiqueta { get; set; }
        public string? Descripcion { get; set; }
    }
}
