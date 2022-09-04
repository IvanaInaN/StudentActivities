using FluentAssertions;
using FormActions.Services.CQRS.Queries.GetAllFormActionsQuery;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FormActions.UnitTests.Services.CQRS.Queries
{
    public class GetAllFormActionsQueryHandlerTest
    {    
        private readonly GetAllFormActionsQueryHandler _handler;

        public GetAllFormActionsQueryHandlerTest()
        {
            _handler = new GetAllFormActionsQueryHandler();
        }

        [Fact]
        public async Task GetAllFormActions()
        {
            // Arrange
            var request = new GetAllFormActionQueryRequest();

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 
            response.Should().NotBeEmpty();
        }
    }
}
