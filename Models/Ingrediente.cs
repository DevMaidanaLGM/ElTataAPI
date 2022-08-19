using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models
{
    public class Ingrediente
    {
        [Key]
        public int Id_Ingrediente { get; set; }
        public int Fk_Id_Tipo_Ingrediente { get ; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }


    }
}
