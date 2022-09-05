using MediatR;
using StudentActivities.Structures.Dtos;
using System.Collections.Generic;

namespace StudentActivities.Services.CQRS.Queries.GetAllFormActionsQuery
{
    public class GetAllStudentActivitiesQueryRequest : IRequest<List<StudentActivitiyDto>>
    {
    }
}
