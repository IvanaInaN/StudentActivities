using AutoMapper;
using StudentActivities.Domain.Models;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;

namespace StudentActivities.Services.AutoMapper
{
    public class MapperFormAction : Profile
    {
        public MapperFormAction()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<List<Student>, List<StudentDto>>();

            CreateMap<Form, FormDto>();
            CreateMap<FormDto, Form>();
            CreateMap<List<Form>, List<FormDto>>();

            CreateMap<StudentActivity, StudentActivitiyDto>();
            CreateMap<StudentActivitiyDto, StudentActivity>();
        }

        private int CalculateWaitingTime(DateTime start)
        {
            var end = DateTime.UtcNow;
            return (int)end.Subtract(start).TotalMinutes;
        }
    }
}
