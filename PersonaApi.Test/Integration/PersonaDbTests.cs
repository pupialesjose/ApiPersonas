using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApiPersonas.Context;
using ApiPersonas.Models;
using ApiPersonas.Repositories;
using PersonaApi.Test.Helpers;
using Xunit;

namespace PersonaApi.Test.Integration
{
    public class PersonaDbTests
    {
        [Fact]
        public async Task AddPersona_ShouldPersistInDatabase()
        {
            // Arrange
            var context = DbContextHelper.GetDbContext();
            var repository = new PersonaRepository(context);

            var persona = new Persona
            {
                Id = 25,
                Name = "Juan",
                Age = 30

            };

            // Act
            await repository.AddAsync(persona);
            var personas = await repository.GetAllAsync();

            // Assert
            Assert.Single(personas);
            Assert.Equal("Juan", personas.First().Name);
        }
    }
}
