using ApiPersonas.Context;
using ApiPersonas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonas.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await GetByIdAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
           return await _context.Personas.ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }
    }
}
