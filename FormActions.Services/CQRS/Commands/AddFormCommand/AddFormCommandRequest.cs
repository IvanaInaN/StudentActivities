using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentActivities.Services.CQRS.Commands.AddFormCommand
{
    public class AddFormCommandRequest : IRequest<AddFormCommandResponse>
    {
        public string Name { get; internal set; }
    }
}
