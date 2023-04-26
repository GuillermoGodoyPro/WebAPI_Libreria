using System.ComponentModel.DataAnnotations;

namespace WebAPI_Libreria.Models
{
    public class Tienda
    {
        [Key]
        public int Codigo { get; set; }
        public string Denominacion { get; set; }
        public string Direccion { get; set; }

    }
}
