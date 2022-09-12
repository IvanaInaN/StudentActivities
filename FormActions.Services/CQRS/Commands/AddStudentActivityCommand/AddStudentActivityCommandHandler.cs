using MediatR;
using StudentActivities.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Commands.AddStudentActivityCommand
{
    public class AddStudentActivityCommandHandler : IRequestHandler<AddStudentActivityCommandRequest, AddStudentActivityCommandResponse>
    {
        private readonly IStudentActivityRepository _studentActivityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddStudentActivityCommandHandler(IStudentActivityRepository studentActivityRepository, IUnitOfWork unitOfWork)
        {
            _studentActivityRepository = studentActivityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddStudentActivityCommandResponse> Handle(AddStudentActivityCommandRequest request, CancellationToken cancellationToken)
        {
            await _studentActivityRepository.AddStudentActivity(request.Activity, request.StudentId, request.FormId);

            await _unitOfWork.SaveChangesAsync();

            return new AddStudentActivityCommandResponse();
        }
    }
}
