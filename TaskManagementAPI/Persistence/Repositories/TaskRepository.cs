using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context) 
        {
            _context = context;
        }

        public Task AddTaskAsync(TaskTable project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskTable>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public Task<TaskTable> GetTaskAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaskAsync(TaskTable project)
        {
            throw new NotImplementedException();
        }
    }
}
