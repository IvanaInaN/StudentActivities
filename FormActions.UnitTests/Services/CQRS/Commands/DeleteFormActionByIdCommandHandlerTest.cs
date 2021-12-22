using FluentAssertions;
using FormActions.Domain.Repositories;
using FormActions.Services.CQRS.Commands.DeleteFormActionByIdCommand;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FormActions.UnitTests.Services.CQRS.Commands
{
    public class DeleteFormActionByIdCommandHandlerTest
    {
        private readonly Mock<IFormActionRepository> _formActionRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly DeleteFormActionByIdCommandHandler _handler;

        public DeleteFormActionByIdCommandHandlerTest()
        {
            _formActionRepositoryMock = new Mock<IFormActionRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new DeleteFormActionByIdCommandHandler(_formActionRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task DeleteById()
        {
            // Arrange

            var request = new DeleteFormActionByIdCommandRequest()
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
