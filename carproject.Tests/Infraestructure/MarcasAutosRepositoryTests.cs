using carproject.Domain.Entities;
using carproject.Infraestructure.Contexts;
using carproject.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace carproject.Tests.Infraestructure
{    
    public class MarcasAutosRepositoryTests
    {
        private ApplicationDbContext GetInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName) // Cada test usa un DB distinto
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllMarcasAutos()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext(nameof(GetAllAsync_ReturnsAllMarcasAutos));

            dbContext.MarcasAutos.AddRange(
                new MarcasAutos { Id = 1, Brand = "Toyota" },
                new MarcasAutos { Id = 2, Brand = "Ford" },
                new MarcasAutos { Id = 3, Brand = "Hyundai" }
            );
            await dbContext.SaveChangesAsync();

            var repository = new MarcasAutosRepository(dbContext);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Equal("Toyota", result.First().Brand);
            Assert.Equal("Hyundai", result.Last().Brand);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsEmpty_WhenNoDataExists()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext(nameof(GetAllAsync_ReturnsEmpty_WhenNoDataExists));
            var repository = new MarcasAutosRepository(dbContext);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
