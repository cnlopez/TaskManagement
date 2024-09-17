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
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context) 
        {
            _context = context;
        }

        public Task AddProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public Task<Project> GetProjectAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
