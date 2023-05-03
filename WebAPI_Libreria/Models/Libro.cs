using System.ComponentModel.DataAnnotations;

namespace WebAPI_Libreria.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public Autor Autor { get; set; }

    }
}
