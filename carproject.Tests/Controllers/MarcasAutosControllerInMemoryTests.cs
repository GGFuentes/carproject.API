using carproject.API.Controller;
using carproject.Application.Dto;
using carproject.Application.Interfaces;
using carproject.Domain.Entities;
using carproject.Infraestructure.Contexts;
using carproject.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carproject.Tests.Controllers
{
    public class MarcasAutosControllerInMemoryTests
    {
        /*private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            dbContext.MarcasAutos.AddRange(
                new MarcasAutos { Id = 1, Brand = "Toyota" },
                new MarcasAutos { Id = 2, Brand = "Ford" }
            );
            dbContext.SaveChanges();

            return dbContext;
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_FromInMemoryDb()
        {
            // Arrange
            var dbContext = GetDbContext();
            var repo = new MarcasAutosRepository(dbContext);
            var service = new MarcasAutosService(repo); // tu implementación real
            var controller = new MarcasAutosController(service);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var marcas = Assert.IsAssignableFrom<IEnumerable<MarcasAutosDto>>(okResult.Value);
            Assert.Equal(2, marcas.Count());
        }*/
    }
}
