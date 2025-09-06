using AutoMapper;
using carproject.Application.Commons.Mappings;
using carproject.Application.Interfaces;
using carproject.Domain.Entities;
using carproject.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace carproject.Tests.Application
{
    public class MarcasAutosServiceTests
    {
        private readonly Mock<IMarcasAutosRepository> _repositoryMock;
        private readonly IMapper _mapper;
        private readonly MarcasAutosService _service;
        private readonly MappingsProfile _mappingsProfile;

        public MarcasAutosServiceTests()
        {
            // Mock del repositorio
            _mappingsProfile= new MappingsProfile();
            _repositoryMock = new Mock<IMarcasAutosRepository>();   
            var configuration = new MapperConfiguration(c =>
            {
                c.AddProfile(_mappingsProfile);
            }, new NullLoggerFactory());
            _mapper = new Mapper(configuration);
            _service = new MarcasAutosService(_repositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedDtos_WhenDataExists()
        {            
            // Arrange           
            IEnumerable<MarcasAutos> entities = new List<MarcasAutos>() 
            { 
                new MarcasAutos { Id = 1, Brand = "Toyota" }, 
                new MarcasAutos { Id = 2, Brand = "Ford" } 
            }.AsEnumerable();

            // Crear el servicio con mocks
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

            // Act
            var result = await _service.GetAllAsync();

            var object1 = result.ToList();
            // Assert
            result.Should().NotBeNull();            
            result.Should().HaveCount(2);
            result.Should().ContainSingle(x => x.Brand == "Toyota");
            result.Should().ContainSingle(x => x.Brand == "Ford");
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmpty_WhenNoDataExists()
        {
            // Crear el servicio con mocks
            // Arrange
            var expectedResult = new List<MarcasAutos>();
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedResult);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }
    }
}
