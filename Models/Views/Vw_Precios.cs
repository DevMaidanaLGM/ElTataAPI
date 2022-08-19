using System.ComponentModel.DataAnnotations;

namespace ElTataAPI.Models.Views
{
    public class Vw_Precios
    {

        [Key]
        public int Id_Precios { get; set; }
        public int Precio { get; set; }
        public string? Sandwich_Nombre { get; set; }
        public string? Sandwich_Descripcion { get; set; }


    }
}
