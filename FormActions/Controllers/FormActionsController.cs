using FormActions.Services.CQRS.Commands.DeleteFormActionByIdCommand;
using FormActions.Services.CQRS.Queries.GetAllFormActionsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FormActions.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FormActionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormActionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormActions()
        {
            var request = new GetAllFormActionQueryRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteFormActionByIdCommandRequest
            {
                FormActionId = id
            };

            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}


