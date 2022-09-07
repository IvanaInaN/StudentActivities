using AutoMapper;
using FluentAssertions;
using StudentActivities.Domain.Models;
using StudentActivities.Services.CQRS.Queries.GetStudentActivitiesQuery;
using StudentActivities.Structures.Dtos;
using StudentActivities.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StudentActivities.UnitTests.Services.CQRS.Queries
{
    public class GetStudentActivitiesQueryHandlerTest : BaseTest
    {
        [Fact]
        public async Task Nothing()
        {
            // Arrange
            var request = new GetStudentActivitiesQueryRequest();

            // Act
            var response = await _context.Mediator.Send(request);

            // Assert
            response.Should().BeNull();
        }

        [Fact]
        public async Task Should_return_student_activities_by_studentId()
        {
            // Arrange
            var request = new GetStudentActivitiesQueryRequest
            {
                StudentId = 24
            };

            var formActions = PrepareDbData();

            _context.FakeStudentActivitiesRepository.SetUp(formActions);

            // Act
            var response = await _context.Mediator.Send(request);

            // Assert

            var expectedResult = new List<StudentActivitiyDto>
            {
                PrepareExpectedStudentActivities()
            };

            response.Should().BeEquivalentTo(expectedResult);
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

        private StudentActivitiyDto PrepareExpectedStudentActivities()
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
    }
}
