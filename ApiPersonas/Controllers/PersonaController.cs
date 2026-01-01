using ApiPersonas.Context;
using ApiPersonas.Models;
using ApiPersonas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        #region anterior
        /// <summary>
        /// private readonly AppDbContext _context;
        /// </summary>

        private readonly IPersonaRepository _repo;

        public PersonaController(IPersonaRepository repo)
        {
            _repo = repo;
        }

        /*
        public PersonaController(AppDbContext context) 
        {
            _context = context;
        }
        */

        // GET: api/Person
        /*
        [HttpGet]
        public async Task<ActionResult> GetPersons()
        {
            return Ok ( await _repo.GetAllAsync());//.ToListAsync();
        }
        */

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAllPersonas()
        {
            var personas = await _repo.GetAllAsync();
            return Ok(personas);
        }


        // GET: api/personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            var persona = await _repo.GetByIdAsync(id);

            if (persona == null)
                return NotFound();

            return Ok(persona);
        }

        // POST: api/personas
        [HttpPost]
        public async Task<ActionResult> Create(Persona persona)
        {
            await _repo.AddAsync(persona);

            return CreatedAtAction(
                nameof(GetById),
                new { id = persona.Id },
                persona
            );
        }


        // PUT: api/personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Persona persona)
        {
            if (id != persona.Id)
                return BadRequest("ID mismatch");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.UpdateAsync(persona);
            return NoContent();
        }


        // DELETE: api/personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
        }

        /*
        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersons()
        {
            return await _context.Personas.ToListAsync();
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPerson(int id)
        {
            var person = await _context.Personas.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Persona person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPerson(Persona person)
        {
            _context.Personas.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Personas.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }

        */

        #endregion 


    }
}
