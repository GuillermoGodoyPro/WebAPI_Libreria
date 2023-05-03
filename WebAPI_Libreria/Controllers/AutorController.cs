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

        private readonly AppDbContext _context;
        public AutorController(AppDbContext context)
        {
            _context = context; // Esto es inyectar dependencias
        }

        /* ---------GET---------*/
        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            var Autores = _context.Autores.ToList();
            return Ok(Autores);
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

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Autor> GetWith(int id)
        {
            var autor = _context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        /*---------POST---------*/
        /*
         * [HttpPost]
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
         
         */
         
        [HttpPost]
        public ActionResult PostOfProof([FromBody] Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();

            //en el primer parámetro le indico donde quiero que vaya, en el segundo crea un objeto para que busque en ese id y le paso autor también
            //osea agrego ese autor, con ese ID a esa ruta (Obtener autor)
            return new CreatedAtRouteResult("ObetenerAutor", new { id = autor.Id }, autor);

        }

        

        /* ---------PUT---------*/
        //UPDATE        
       
        /*
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
        */

        [HttpPut("{id}")]
        public ActionResult Put( int id, [FromBody] Autor autor)
        {
            if( id != autor.Id)
            {
                return BadRequest();
            }
            _context.Entry(autor).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }


        /* ---------DELETE---------*/

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
            /*
            var result = _context.Autores.FirstOrDefault(a=>a.Id == id);
            if(result == null){
                return NotFound();
            }
            _context.Autores.Remove(autorDeleted);
            _context.SaveChanges();
             
            return autorDeleted;
             */
        }

        /*
        //SELECT BY ID
        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {
            var autorById = (from d in _context.Autores
                             where d.Id == id
                             select d).SingleOrDefault();
            return autorById;
        } 
         */

    }
}
