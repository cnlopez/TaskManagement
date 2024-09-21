using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectViewModel>> GetProjectViewModelsAsync();
        Task<ProjectViewModel> GetProjectViewModelByIdAsync(int id);
        Task AddProjectAsync(ProjectViewModel project);
        Task UpdateProjectAsync(int id, ProjectViewModel project);
        Task DeleteProjectAsync(int id);

    }
}
