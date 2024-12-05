using Application.Interfaces;
using Application.Mappers;
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
        private readonly IMapper _mapper; // Mock para IMapper
        private readonly IProjectService _projectService;

        public ProjectServiceTests()
        {
            var profiles = new Profile[] { new ProjectMapper() };
            var mappingConfig = new MapperConfiguration(x => x.AddProfiles(profiles));
            _mapper = mappingConfig.CreateMapper();

            _projectRepositoryMock = new Mock<IProjectRepository>();
            _projectService = new ProjectService(_projectRepositoryMock.Object, _mapper);
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
