using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
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

        public async Task AddTaskAsync(TaskViewModel taskVM)
        {
            var task = _mapper.Map<TaskTable>(taskVM);
            await _taskRepository.AddTaskAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
        }

        public async Task<TaskViewModel> GetTaskViewModelByIdAsync(int id)
        {
            var task = await _taskRepository.GetTaskAsync(id);
            var taskVM = _mapper.Map<TaskViewModel>(task);
            return taskVM;
        }

        public async Task<IEnumerable<TaskViewModel>> GetTaskViewModelsAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            var tasksVM = _mapper.Map<IEnumerable<TaskViewModel>>(tasks);
            return tasksVM;
        }

        public async Task UpdateTaskAsync(TaskViewModel taskVM)
        {
            var task = _mapper.Map<TaskTable>(taskVM);
            await _taskRepository.UpdateTaskAsync(task);
        }
    }
}
