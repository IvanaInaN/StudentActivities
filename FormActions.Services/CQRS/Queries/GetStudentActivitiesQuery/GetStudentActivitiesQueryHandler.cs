using AutoMapper;
using MediatR;
using StudentActivities.Domain.Models;
using StudentActivities.Domain.Repositories;
using StudentActivities.Structures;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Queries.GetStudentActivitiesQuery
{
    public class GetStudentActivitiesQueryHandler : IRequestHandler<GetStudentActivitiesQueryRequest, List<StudentActivitiyDto>>
    {
        private readonly IStudentActivityRepository _studentActivityRepository;
        private IMapper _mapper;
        private const string ErrorMessage = "Student with id: {0} doesn't exist!";

        public GetStudentActivitiesQueryHandler(IStudentActivityRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _studentActivityRepository = repository;
        }

        public async Task<List<StudentActivitiyDto>> Handle(GetStudentActivitiesQueryRequest request, CancellationToken cancellationToken)
        {
            var studentId = request.StudentId;

            var errorMessage = string.Format(Constants.InvalidStudentIdError, studentId);

            if (studentId <= 0)
            {
                throw new ArgumentOutOfRangeException("", errorMessage);
            }

            var result = await _studentActivityRepository.GetStudentActivitiesByStudentIdAsync(request.StudentId);

            var studentActivities = _mapper.Map<List<StudentActivity>, List<StudentActivitiyDto>>(result);

            return studentActivities;
        }
    }
}
