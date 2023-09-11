using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using static Todo.Core.Features.TodoFeature.ActiveTodoList;

namespace Todo.Web.Controllers.TodoEndpoint
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/Todo")]
    public class ActiveTodoList : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<IEnumerable<TodoItem>>
    {
        private readonly IMediator mediator;

        public ActiveTodoList(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("ActiveList")]
        public override async Task<ActionResult<IEnumerable<TodoItem>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(new ActiveTodoListCommand(), cancellationToken));
        }
    }
}
