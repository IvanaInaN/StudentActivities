using MediatR;

namespace StudentActivities.Services.CQRS.Commands.DeleteStudentActivityByIdCommand
{
    public class DeleteStudentActivityByIdCommandRequest : IRequest<DeleteStudentActivityByIdCommandResponse>
    {
        public int FormActionId { get; set; }
    }
}
