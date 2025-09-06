using carproject.API.Controller;
using carproject.Application.Dto;
using carproject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace carproject.Tests.Controllers
{
    public class MarcasAutosControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithExpectedData()
        {
            // Arrange
            var mockService = new Mock<IMarcasAutosService>();
            mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<MarcasAutosDto>
        {
            new MarcasAutosDto { Id = 1, Brand = "Toyota" },
            new MarcasAutosDto { Id = 2, Brand = "Ford" }
        });

            var controller = new MarcasAutosController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<MarcasAutosDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }
    }
}
