using AutoMapper;
using MediatR;
using StudentActivities.Domain.Models;
using StudentActivities.Domain.Repositories;
using StudentActivities.Structures;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var shouldThrowArgumentOutOfRangeException = studentId <= 0;

            ValidateStudentId(shouldThrowArgumentOutOfRangeException, errorMessage);

            var result = await _studentActivityRepository.GetStudentActivitiesByStudentIdAsync(request.StudentId);

            var studentActivities = _mapper.Map<List<StudentActivity>, List<StudentActivitiyDto>>(result);

            shouldThrowArgumentOutOfRangeException = !studentActivities.Any();

            ValidateStudentId(shouldThrowArgumentOutOfRangeException, errorMessage);

            return studentActivities;
        }

        private static void ValidateStudentId(bool invalidStudentId, string errorMessage)
        {
            if (invalidStudentId)
            {
                throw new ArgumentOutOfRangeException("", errorMessage);
            }
        }
    }
}
