using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI_Libreria.Contexto;
using WebAPI_Libreria.Models;

namespace WebAPI_Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AppDbContext _context;
        public AutorController(AppDbContext context)
        {
            _context = context; // Esto es inyectar dependencias
        }

        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            var Autores = _context.Autores.ToList();

            return Ok(Autores);
        }



        [HttpPost]
        public ActionResult Post(Autor d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Autores.Add(d);
            _context.SaveChanges();
            return Ok();
        }

        //SELECT BY NAME
        [HttpGet("name/{name}")]
        public ActionResult<Autor> GetByName(string name)
        {
            var nombreGet = (from d in _context.Autores
                             where d.Nombre == name
                             select d).SingleOrDefault();

            return nombreGet;
        }

        //UPDATE        
        [HttpPut("{id}")]
        public ActionResult Put(int id, Autor d)
        {
            if (id != d.Id)
            {
                return BadRequest();
            }

            _context.Entry(d).State = EntityState.Modified; // Es para actualizar todo el modelo
            _context.SaveChanges();
            return Ok();
        }

        //DELETE        
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autorDeleted = (from d in _context.Autores
                                where d.Id == id
                                select d).SingleOrDefault();

            if (autorDeleted == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autorDeleted);
            _context.SaveChanges();

            return autorDeleted;

        }
        //SELECT BY ID
        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {
            var autorById = (from d in _context.Autores
                             where d.Id == id
                             select d).SingleOrDefault();
            return autorById;
        }



    }
}
