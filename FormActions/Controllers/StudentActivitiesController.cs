using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentActivities.Services.CQRS.Commands.DeleteStudentActivityByIdCommand;
using StudentActivities.Services.CQRS.Queries.GetAllFormActionsQuery;
using StudentActivities.Services.CQRS.Queries.GetStudentActivitiesQuery;
using StudentActivities.Structures.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentActivities.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudentActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormActions()
        {
            var request = new GetAllStudentActivitiesQueryRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentActivitiesByStudentId(int id)
        {
            var request = new GetStudentActivitiesQueryRequest()
            {
                StudentId = id
            };

            List<StudentActivitiyDto> result;

            try
            {
                result = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteStudentActivityByIdCommandRequest
            {
                FormActionId = id
            };

            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}


