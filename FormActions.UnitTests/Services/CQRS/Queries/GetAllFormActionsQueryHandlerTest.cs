using FluentAssertions;
using StudentActivities.Services.CQRS.Queries.GetAllFormActionsQuery;
using StudentActivities.Services.CQRS.Queries.GetAllStudentActivitiesQuery;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FormActions.UnitTests.Services.CQRS.Queries
{
    public class GetAllFormActionsQueryHandlerTest
    {
        private readonly GetAllStudentActivitiesQueryHandler _handler;

        public GetAllFormActionsQueryHandlerTest()
        {
            _handler = new GetAllStudentActivitiesQueryHandler();
        }

        [Fact]
        public async Task Nothing()
        {
            // Arrange
            var request = new GetAllStudentActivitiesQueryRequest();

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 
            response.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Should_return_list_of_form_actions()
        {
            // Arrange
            var request = new GetAllStudentActivitiesQueryRequest();

            var formActionDto = new StudentActivitiyDto
            {
                Action = "Test started",
                ActionOn = new DateTime(2021, 12, 1, 4, 6, 23),
                FormId = 12,
                Form = new FormDto
                {
                    Active = 1,
                    Id = 12,
                    Name = "General knowlage test"
                },
                StudentId = 24,
                Student = new StudentDto
                {
                    
                }
            };

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 
            var expectedResult = new List<StudentActivitiyDto>
            {

            };
            response.Should().NotBeEmpty();
        }
    }
}
