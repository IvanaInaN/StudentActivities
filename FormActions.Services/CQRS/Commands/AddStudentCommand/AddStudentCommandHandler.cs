using MediatR;
using StudentActivities.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Commands.AddStudentCommand
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommandRequest, AddStudentCommandResponse>
    {
        private readonly IStudentActivityRepository _studentActivityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddStudentCommandHandler(IStudentActivityRepository studentActivityRepository, IUnitOfWork unitOfWork)
        {
            _studentActivityRepository = studentActivityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddStudentCommandResponse> Handle(AddStudentCommandRequest request, CancellationToken cancellationToken)
        {
            await _studentActivityRepository.AddStudent(request.Name, request.City, request.Street, request.Email, request.Phone);

            await _unitOfWork.SaveChangesAsync();

            return new AddStudentCommandResponse();
        }
    }
}
