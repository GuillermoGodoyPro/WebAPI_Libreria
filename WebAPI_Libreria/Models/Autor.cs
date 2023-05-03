using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebAPI_Libreria.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Error en nombre")]
        [Column(TypeName = "varchar(20)")]
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }

    }
}
