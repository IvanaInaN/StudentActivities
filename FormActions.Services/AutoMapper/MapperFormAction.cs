using AutoMapper;
using FormActions.Domain.Models;
using FormActions.Structures.Dtos;
using System.Collections.Generic;

namespace FormActions.Services.AutoMapper
{
    public class MapperFormAction : Profile
    {
        public MapperFormAction()
        {
            CreateMap<Candidate, CandidateDto>();
            CreateMap<CandidateDto, Candidate>();
            CreateMap<List<Candidate>, List<CandidateDto>>();

            CreateMap<Form, FormDto>();
            CreateMap<FormDto, Form>();
            CreateMap<List<Form>, List<FormDto>>();

            CreateMap<FormAction, FormActionDto>();
            CreateMap<FormActionDto, FormAction>();
           // CreateMap<List<FormAction>, List<FormActionDto>>();
        }
    }
}
