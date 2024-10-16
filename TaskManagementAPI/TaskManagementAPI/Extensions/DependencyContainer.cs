using Application.Interfaces;
using Application.Mappers;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Persistence.Repositories;

namespace TaskManagementAPI.Extensions
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }

        public static IServiceCollection RegisterExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            var profiles = new Profile[] { new ProjectMapper(), new TaskMapper() };
            services.AddAutoMapper(profiles);
            return services;
        }
    }
}
