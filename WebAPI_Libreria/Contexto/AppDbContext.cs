using Microsoft.EntityFrameworkCore;
using WebAPI_Libreria.Models;

namespace WebAPI_Libreria.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options ) : base(options) {}

        public DbSet<Autor> Autores { get; set; }
        //public DbSet<>

    }
}
