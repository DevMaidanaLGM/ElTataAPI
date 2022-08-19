using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models.Views
{
    public class Vw_Ingredientes_Recetas
    {
        [Key]
        public int Id_Ingrediente_Receta { get; set; }
        public int Id_Receta { get; set; }
        public int Id_Ingrediente { get; set; }
        public string? Receta_Nombre { get; set; }
        public string? Receta_Descripcion { get; set; }
        public string? Ingrediente_Nombre { get; set; }
        public int Ingrediente_Cantidad { get; set; }
        public string? Sandwich_Nombre { get; set; }

    }
}
