using MediatR;
using StudentActivities.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Commands.AddFormCommand
{
    public class AddFormCommandHandler : IRequestHandler<AddFormCommandRequest, AddFormCommandResponse>
    {
        private readonly IStudentActivityRepository _studentActivityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddFormCommandHandler(IStudentActivityRepository studentActivityRepository, IUnitOfWork unitOfWork)
        {
            _studentActivityRepository = studentActivityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddFormCommandResponse> Handle(AddFormCommandRequest request, CancellationToken cancellationToken)
        {
            await _studentActivityRepository.AddForm(request.Name);

            await _unitOfWork.SaveChangesAsync();

            return new AddFormCommandResponse();
        }
    }
}
