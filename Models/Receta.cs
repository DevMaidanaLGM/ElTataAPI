using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class Receta
    {
        [Key]
        public int Id_Receta { get; set; }
        public int Fk_Id_Sandwich { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }


    }
}
