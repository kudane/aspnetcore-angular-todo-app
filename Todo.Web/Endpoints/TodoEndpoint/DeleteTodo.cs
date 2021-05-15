using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using static Todo.Core.Features.TodoFeature.DeleteTodo;

namespace Todo.Web.Controllers.TodoEndpoint
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/Todo")]
    public class DeleteTodo : BaseAsyncEndpoint
        .WithRequest<DeleteTodoCommand>
        .WithoutResponse
    {
        private readonly IMediator mediator;

        public DeleteTodo(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpDelete("Delete")]
        public override async Task<ActionResult> HandleAsync([FromQuery] DeleteTodoCommand request, CancellationToken cancellationToken = default)
        {
            await mediator.Send(request, cancellationToken);
            return Ok();
        }
    }
}
