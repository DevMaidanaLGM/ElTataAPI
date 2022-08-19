using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class IngredientesReceta
    {
        [Key]
        public int Id_Ingrediente_Receta { get; set; }  
        public int Fk_Id_Receta { get; set; }
        public int Fk_Id_Ingrediente { get; set; }
        public int Cantidad { get; set; }

    }
}
