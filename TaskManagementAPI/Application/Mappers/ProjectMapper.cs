using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class ProjectMapper : Profile
{
    public ProjectMapper() 
    {
        CreateMap<ProjectViewModel, Project>();
        CreateMap<Project, ProjectViewModel>();
    }
}
