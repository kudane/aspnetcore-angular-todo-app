using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using static Todo.Core.Features.TodoFeature.AddTodo;

namespace Todo.Web.Controllers.TodoEndpoint
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/Todo")]
    public class AddTodo : EndpointBaseAsync
        .WithRequest<AddTodoCommand>
        .WithActionResult<TodoItem>
    {
        private readonly IMediator mediator;

        public AddTodo(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Add")]
        public override async Task<ActionResult<TodoItem>> HandleAsync(AddTodoCommand request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
