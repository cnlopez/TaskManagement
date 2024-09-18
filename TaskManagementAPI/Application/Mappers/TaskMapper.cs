using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class TaskMapper : Profile
    {
        public TaskMapper() 
        {
            CreateMap<TaskViewModel, TaskTable>();
            CreateMap<TaskTable, TaskViewModel>();
        }
    }
}
