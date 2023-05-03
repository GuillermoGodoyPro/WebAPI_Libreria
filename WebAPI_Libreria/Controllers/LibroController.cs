using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebAPI_Libreria.Contexto;
using WebAPI_Libreria.Models;

namespace WebAPI_Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LibroController(AppDbContext context)
        {
            _context = context; // Esto es inyectar dependencias
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            var LibroR = _context.Libros.Include(a => a.Autor).ToList();
            return Ok(LibroR);
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.Id == id);

            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);   

        }


        [HttpPost]
        public ActionResult Post([FromBody] Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();

            return Ok();

        }




    }
}
