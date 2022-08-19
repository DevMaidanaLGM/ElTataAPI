using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models.Views
{
    public class Vw_Recetas
    {
        [Key]
        public int Id_Receta { get; set; }
        public int Id_Sandwich { get; set; }
        public string? Sandwich_Nombre { get; set; }
        public string? Sandwich_Descripcion { get; set; }

        public string? Receta_Nombre { get; set; }
        public string? Receta_Descripcion { get; set; }

    }
}
