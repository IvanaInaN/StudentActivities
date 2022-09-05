using FluentAssertions;
using Moq;
using StudentActivities.Domain.Repositories;
using StudentActivities.Services.CQRS.Commands.DeleteStudentActivityByIdCommand;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FormActions.UnitTests.Services.CQRS.Commands
{
    public class DeleteStudentActivitiesByIdCommandHandlerTest
    {
        private readonly Mock<IStudentActivityRepository> _formActionRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly DeleteStudentActivityByIdCommandHandler _handler;

        public DeleteStudentActivitiesByIdCommandHandlerTest()
        {
            _formActionRepositoryMock = new Mock<IStudentActivityRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new DeleteStudentActivityByIdCommandHandler(_formActionRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task DeleteById()
        {
            // Arrange

            var request = new DeleteStudentActivityByIdCommandRequest()
            {
                FormActionId = 1
            };

            _formActionRepositoryMock.Setup(x => x.RemoveById(1));

            // Act

            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 

            response.Should().NotBeNull();

            _formActionRepositoryMock.VerifyAll();
        }
    }
}
