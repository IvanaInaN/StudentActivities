using MediatR;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentActivities.Services.CQRS.Queries.GetStudentActivitiesQuery
{
    public class GetStudentActivitiesQueryRequest : IRequest<List<StudentActivitiyDto>>
    {
        public int StudentId { get; set; }
    }
}
