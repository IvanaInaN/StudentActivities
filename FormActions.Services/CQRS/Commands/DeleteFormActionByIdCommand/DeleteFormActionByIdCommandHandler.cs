using FormActions.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FormActions.Services.CQRS.Commands.DeleteFormActionByIdCommand
{
    public class DeleteFormActionByIdCommandHandler : IRequestHandler<DeleteFormActionByIdCommandRequest, DeleteFormActionByIdCommandResponse>
    {
        private readonly IFormActionRepository _formActionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFormActionByIdCommandHandler(IFormActionRepository formActionRepository,
            IUnitOfWork unitOfWork)
        {
            _formActionRepository = formActionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteFormActionByIdCommandResponse> Handle(DeleteFormActionByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var formAcrtionId = request.FormActionId;

            await _formActionRepository.RemoveById(formAcrtionId);

            await _unitOfWork.SaveChangesAsync();

            return new DeleteFormActionByIdCommandResponse();
        }
    }
}
