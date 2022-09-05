using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentActivities.Services.CQRS.Commands.DeleteStudentActivityByIdCommand;
using StudentActivities.Services.CQRS.Queries.GetAllFormActionsQuery;
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


