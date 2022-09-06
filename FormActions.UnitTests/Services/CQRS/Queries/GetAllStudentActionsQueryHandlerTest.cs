using AutoMapper;
using FluentAssertions;
using Moq;
using StudentActivities.Domain.Models;
using StudentActivities.Domain.Repositories;
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
    public class GetAllStudentActionsQueryHandlerTest
    {
        private readonly Mock<IStudentActivityRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapper;
        private readonly GetAllStudentActivitiesQueryHandler _handler;

        public GetAllStudentActionsQueryHandlerTest()
        {
            _repositoryMock = new Mock<IStudentActivityRepository>(MockBehavior.Strict);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
            _handler = new GetAllStudentActivitiesQueryHandler(_repositoryMock.Object, _mapper.Object);
        }

        [Fact]
        public async Task Nothing()
        {
            // Arrange
            var request = new GetAllStudentActivitiesQueryRequest();
            var formActions = PrepareDbData();
            var formActionsDto = PrepareOutputData();

            _repositoryMock.Setup(x => x.GetStudentActivitiesAsync())
                .Returns(Task.FromResult(formActions));

            _mapper.Setup(x => x.Map<List<StudentActivity>, List<StudentActivitiyDto>>(formActions))
                .Returns(formActionsDto);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 
            response.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Should_return_list_of_student_activities()
        {
            // Arrange
            var request = new GetAllStudentActivitiesQueryRequest();
            var formActions = PrepareDbData();
            var formActionsDto = PrepareOutputData();

            _repositoryMock.Setup(x => x.GetStudentActivitiesAsync())
                .Returns(Task.FromResult(formActions));

            _mapper.Setup(x => x.Map<List<StudentActivity>, List<StudentActivitiyDto>>(formActions))
                .Returns(formActionsDto);

            // Act

            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert 
            var expectedResult = new List<StudentActivitiyDto>
            { 
                PrepareExpectedStudentActivities()
            };

            response.Should().BeEquivalentTo(expectedResult);

            _repositoryMock.Verify(x => x.GetStudentActivitiesAsync(), Times.Once);
            _mapper.VerifyAll();
        }

        private static StudentActivitiyDto PrepareExpectedStudentActivities()
        {
            return new StudentActivitiyDto
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
                    Name = "Nikola",
                    Active = 1,
                    City = "Belgrade",
                    Email = "nngmail.com",
                    PhoneNumber = "061 111 222 33",
                    Street = "Timocka",
                    Id = 24
                },
                Id = 31
            };
        }

        private static List<StudentActivity> PrepareDbData()
        {
            return new List<StudentActivity>
            {
                new StudentActivity
                {
                    Action = "Test started",
                    ActionOn = new DateTime(2021, 12, 1, 4, 6, 23),
                    FormId = 12,
                    Form = new Form
                    {
                        Active = 1,
                        Id = 12,
                        Name = "General knowlage test"
                    },
                    StudentId = 24,
                    Student = new Student
                    {
                        Name = "Nikola",
                        Active = 1,
                        City = "Belgrade",
                        Email = "nngmail.com",
                        PhoneNumber = "061 111 222 33",
                        Street = "Timocka",
                        Id = 24
                    },
                    Id = 31
                }
        };
        }

        private static List<StudentActivitiyDto> PrepareOutputData()
        {
            return new List<StudentActivitiyDto> {
                new StudentActivitiyDto
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
                        Name = "Nikola",
                        Active = 1,
                        City = "Belgrade",
                        Email = "nngmail.com",
                        PhoneNumber = "061 111 222 33",
                        Street = "Timocka",
                        Id = 24
                    },
                    Id = 31
                }
        };
        }
    }
}
