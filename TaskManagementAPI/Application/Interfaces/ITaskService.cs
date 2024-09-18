using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetTaskViewModelsAsync();
        Task<TaskViewModel> GetTaskViewModelByIdAsync(int id);
        Task AddTaskAsync(TaskViewModel task);
        Task UpdateTaskAsync(TaskViewModel task);
        Task DeleteTaskAsync(int id);

    }
}
