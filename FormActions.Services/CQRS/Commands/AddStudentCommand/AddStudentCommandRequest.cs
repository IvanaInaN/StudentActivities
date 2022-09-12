using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentActivities.Services.CQRS.Commands.AddStudentCommand
{
    public class AddStudentCommandRequest : IRequest<AddStudentCommandResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
