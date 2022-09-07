using FluentAssertions;
using StudentActivities.Services.CQRS.Queries.GetStudentActivitiesQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudentActivities.UnitTests.Services.CQRS.Queries
{
    public class GetStudentActivitiesQueryHandlerTest
    {
        private readonly GetStudentActivitiesQueryHandler _handler;

        public GetStudentActivitiesQueryHandlerTest()
        {
            _handler = new GetStudentActivitiesQueryHandler();
        }

        [Fact]
        public async Task Nothing()
        {
            // Arrange
            var request = new GetStudentActivitiesQueryRequest();

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
        }
    }
}
