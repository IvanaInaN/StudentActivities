using AutoMapper;
using MediatR;
using StudentActivities.Services.CQRS.Queries.GetAllFormActionsQuery;
using StudentActivities.Structures.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Queries.GetAllStudentActivitiesQuery
{
    public class GetAllStudentActivitiesQueryHandler : IRequestHandler<GetAllStudentActivitiesQueryRequest, List<StudentActivitiyDto>>
    {
        public GetAllStudentActivitiesQueryHandler() { }

        public Task<List<StudentActivitiyDto>> Handle(GetAllStudentActivitiesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new List<StudentActivitiyDto>()
            {
                new StudentActivitiyDto()
            };
            return Task.FromResult(result);
        }
    }
}
