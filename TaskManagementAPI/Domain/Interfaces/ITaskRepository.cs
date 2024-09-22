using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskTable>> GetAllTasksAsync();
        Task<TaskTable> GetTaskAsync(int id);
        Task AddTaskAsync(TaskTable project);
        Task UpdateTaskAsync(TaskTable project);
        Task DeleteTaskAsync(int id);
    }
}
