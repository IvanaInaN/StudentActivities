using MediatR;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Queries.GetStudentActivitiesQuery
{
    public class GetStudentActivitiesQueryHandler : IRequestHandler<GetStudentActivitiesQueryRequest, StudentActivitiyDto>
    {
        public Task<StudentActivitiyDto> Handle(GetStudentActivitiesQueryRequest request, CancellationToken cancellationToken)
        {
            var res = new StudentActivitiyDto();
            return Task.FromResult(res);
        }
    }
}
