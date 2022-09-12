using MediatR;
using StudentActivities.Domain.Repositories;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Queries.GetAllStudentQuery
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQueryRequest, List<StudentDto>>
    {
        private readonly IStudentActivityRepository _studentActivityRepository;

        public GetAllStudentQueryHandler(IStudentActivityRepository studentActivityRepository)
        {
            _studentActivityRepository = studentActivityRepository;
        }

        public async Task<List<StudentDto>> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
        {
            var students = await _studentActivityRepository.GetStudentsAsync();

            var result = students.Select(x => new StudentDto
            {
                Active =1,
                Email = x.Email,
                City = x.City,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Street = x.Street
            }).ToList();

            return result;
        }
    }
}
