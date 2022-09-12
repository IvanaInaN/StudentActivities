using MediatR;
using StudentActivities.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace StudentActivities.Services.CQRS.Commands.DeleteStudentActivityByIdCommand
{
    public class DeleteStudentActivityByIdCommandHandler : IRequestHandler<DeleteStudentActivityByIdCommandRequest, DeleteStudentActivityByIdCommandResponse>
    {
        private readonly IStudentActivityRepository _formActionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentActivityByIdCommandHandler(IStudentActivityRepository formActionRepository,
            IUnitOfWork unitOfWork)
        {
            _formActionRepository = formActionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteStudentActivityByIdCommandResponse> Handle(DeleteStudentActivityByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var formAcrtionId = request.FormActionId;

            _formActionRepository.RemoveById(formAcrtionId);

            await _unitOfWork.SaveChangesAsync();


            return new DeleteStudentActivityByIdCommandResponse();
        }
    }
}
