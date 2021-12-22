using AutoMapper;
using ComplexApp.Services.CQRS.Queries.GetAllFormActionsQuery;
using FormActions.Domain.Models;
using FormActions.Domain.Repositories;
using FormActions.Services.CQRS.Queries.GetAllFormActionsQuery;
using FormActions.Structures.Dtos;
using Moq;
using System.Collections.Generic;
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
            _formActionRepository = new Mock<IFormActionRepository>(MockBehavior.Strict);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
            _handler = new GetAllFormActionsQueryHandler(_formActionRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetAllFormActions()
        {
            // Arrange

            var request = new GetAllFormActionQueryRequest();

            var result = new List<FormAction>();

            var formActions = new List<FormActionDto>();

            _formActionRepository.Setup(x => x.GetFormActionsAsync())
                .Returns(Task.FromResult(result));

            _mapper.Setup(x => x.Map<List<FormAction>, List<FormActionDto>>(result))
                .Returns(formActions);

            // Act

            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 

            _formActionRepository.Verify(x => x.GetFormActionsAsync(), Times.Once);
            _mapper.VerifyAll();
        }
    }
}
