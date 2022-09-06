using AutoMapper;
using MediatR;
using StudentActivities.Domain.Models;
using StudentActivities.Domain.Repositories;
using StudentActivities.Services.CQRS.Queries.GetAllFormActionsQuery;
using StudentActivities.Structures.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Queries.GetAllStudentActivitiesQuery
{
    public class GetAllStudentActivitiesQueryHandler : IRequestHandler<GetAllStudentActivitiesQueryRequest, List<StudentActivitiyDto>>
    {
        private readonly IStudentActivityRepository _studentActivitiesRepository;
        private readonly IMapper _mapper;

        public GetAllStudentActivitiesQueryHandler(IStudentActivityRepository formActionRepository,
            IMapper mapper)
        {
            _studentActivitiesRepository = formActionRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentActivitiyDto>> Handle(GetAllStudentActivitiesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _studentActivitiesRepository.GetStudentActivitiesAsync();

            var studentActivities = _mapper.Map<List<StudentActivity>, List<StudentActivitiyDto>>(result);

            return studentActivities;
        }
    }
}
