using MediatR;

namespace FormActions.Services.CQRS.Commands.DeleteFormActionByIdCommand
{
    public class DeleteFormActionByIdCommandRequest : IRequest<DeleteFormActionByIdCommandResponse>
    {
        public int FormActionId { get; set; }
    }
}
