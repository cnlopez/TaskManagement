using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace TaskManagementAPI.Tests
{
    public class ProjectServiceTests
    {
        private readonly Mock<IProjectRepository> _projectRepositoryMock;
        private readonly Mock<IMapper> _mapperMock; // Mock para IMapper
        private readonly ProjectService _projectService;

        public ProjectServiceTests()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _mapperMock = new Mock<IMapper>(); // Inicialización del mock de IMapper
            _projectService = new ProjectService(_projectRepositoryMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task GetProjectById_ShouldReturnProject_WhenProjectExists()
        {
            // Arrange
            var projectId = 1;
            var project = new Project { Id = projectId, Name = "Test Project" };
            _projectRepositoryMock.Setup(repo => repo.GetProjectByIdAsync(projectId))
                .ReturnsAsync(project);

            // Act
            var result = await _projectService.GetProjectViewModelByIdAsync(projectId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Project", result.Name);
        }
    }
}
