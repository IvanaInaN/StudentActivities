using MediatR;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentActivities.Services.CQRS.Queries.GetAllStudentQuery
{
    public class GetAllStudentQueryRequest : IRequest<List<StudentDto>>
    {
    }
}
