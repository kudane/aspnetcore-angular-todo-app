using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using static Todo.Core.Features.TodoFeature.MarkTodoAsCompleted;

namespace Todo.Web.Controllers.TodoEndpoint
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/Todo")]
    public class MarkTodoAsCompleted : EndpointBaseAsync
        .WithRequest<MarkTodoAsCompleteCommand>
        .WithoutResult
    {
        private readonly IMediator mediator;

        public MarkTodoAsCompleted(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("MarkAsCompleted")]
        public override async Task<ActionResult> HandleAsync([FromQuery] MarkTodoAsCompleteCommand request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
            return Ok();
        }
    }
}
