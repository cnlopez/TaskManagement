using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public Task AddTaskAsync(TaskViewModel task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskViewModel> GetTaskViewModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskViewModel>> GetTaskViewModelsAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            var tasksVM = _mapper.Map<IEnumerable<TaskViewModel>>(tasks);
            return tasksVM;
        }

        public Task UpdateTaskAsync(TaskViewModel task)
        {
            throw new NotImplementedException();
        }
    }
}
