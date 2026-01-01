using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApiPersonas.Models;
using ApiPersonas.Repositories;
using PersonaApi.Test.Helpers;
using Xunit;

namespace PersonaApi.Test
{
    public class PersonaRepositoryTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsPersonas()
        {
            // Arrange
            var context = DbContextHelper.CreateInMemoryContext(); //GetInMemoryDbContext();

            context.Personas.Add(new Persona { Name = "Juan", Age = 15 });
            context.Personas.Add(new Persona { Name = "Ana", Age = 20 });
            await context.SaveChangesAsync();

            var repo = new PersonaRepository(context);

            // Act
            var personas = await repo.GetAllAsync();

            // Assert
            Assert.NotNull(personas);
            Assert.Equal(2, personas.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCorrectPersona()
        {
            var context = DbContextHelper.CreateInMemoryContext();

            var persona = new Persona { Name = "Carlos", Age = 15 };
            context.Personas.Add(persona);
            await context.SaveChangesAsync();

            var repo = new PersonaRepository(context);

            var result = await repo.GetByIdAsync(persona.Id);

            Assert.NotNull(result);
            Assert.Equal("Carlos", result!.Name);
        }

        [Fact]
        public async Task AddAsync_AddsPersonaToDatabase()
        {
            var context = DbContextHelper.CreateInMemoryContext();
            var repo = new PersonaRepository(context);

            var persona = new Persona { Name = "Lucia", Age = 30 };

            await repo.AddAsync(persona);
            var personas = await repo.GetAllAsync();

            Assert.Single(personas);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesPersonaData()
        {
            var context = DbContextHelper.CreateInMemoryContext();

            var persona = new Persona { Name = "Pedro", Age = 20 };
            context.Personas.Add(persona);
            await context.SaveChangesAsync();

            var repo = new PersonaRepository(context);

            persona.Name = "Pedro Actualizado";
            await repo.UpdateAsync(persona);

            var updated = await repo.GetByIdAsync(persona.Id);

            Assert.Equal("Pedro Actualizado", updated!.Name);
        }

        [Fact]
        public async Task DeleteAsync_RemovesPersona()
        {
            var context = DbContextHelper.CreateInMemoryContext();

            var persona = new Persona { Name = "Luis", Age = 18 };
            context.Personas.Add(persona);
            await context.SaveChangesAsync();

            var repo = new PersonaRepository(context);

            await repo.DeleteAsync(persona.Id);
            var personas = await repo.GetAllAsync();

            Assert.Empty(personas);
        }

    }
}
