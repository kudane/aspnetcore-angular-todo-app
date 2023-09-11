using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using static Todo.Core.Features.TodoFeature.ClearTodoCompleted;

namespace Todo.Web.Controllers.TodoEndpoint
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/Todo")]
    public class ClearTodoCompleted : EndpointBaseAsync
        .WithoutRequest
        .WithoutResult
    {
        private readonly IMediator mediator;

        public ClearTodoCompleted(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("ClearAllCompleted")]
        public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            await mediator.Send(new ClearTodoCompleteCommand(), cancellationToken);
            return Ok();
        }
    }
}
