using AutoMapper;
using ComplexApp.Services.CQRS.Queries.GetAllFormActionsQuery;
using FormActions.Domain.Repositories;
using FormActions.Services.CQRS.Queries.GetAllFormActionsQuery;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FormActions.UnitTests.Services.CQRS.Queries
{
    public class GetAllFormActionsQueryHandlerTest
    {
        private readonly Mock<IFormActionRepository> _formActionRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly GetAllFormActionsQueryHandler _handler;

        public GetAllFormActionsQueryHandlerTest()
        {
            _formActionRepository = new Mock<IFormActionRepository>();
            _formActionRepository = new Mock<IFormActionRepository>();
            _handler = new GetAllFormActionsQueryHandler(_formActionRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetAllFormActions()
        {
            // Arrange

            var request = new GetAllFormActionQueryRequest();

            // Act

            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 

            _formActionRepository.Verify(x => x.GetFormActionsAsync(), Times.Once);
            _mapper.VerifyAll();
        }
    }
}
