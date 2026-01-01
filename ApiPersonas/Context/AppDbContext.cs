using ApiPersonas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonas.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
