using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentActivities.Services.CQRS.Commands.AddStudentActivityCommand
{
    public class AddStudentActivityCommandRequest : IRequest<AddStudentActivityCommandResponse>
    {
        public string Activity { get; set; }
        public int StudentId { get; set; }
        public int FormId { get; set; }
    }
}
