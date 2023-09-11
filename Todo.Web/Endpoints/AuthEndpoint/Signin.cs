using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using static Todo.Core.Features.AuthFeature.Signin;

namespace Todo.Web.Controllers.TodoEndpoint
{
    [AllowAnonymous]
    [ApiController]
    [Route("/Auth")]
    public class Signin : EndpointBaseAsync
        .WithRequest<SigninCommand>
        .WithActionResult<SigninResponse>
    {
        private readonly IMediator mediator;

        public Signin(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Signin")]
        public override async Task<ActionResult<SigninResponse>> HandleAsync([FromBody] SigninCommand request, CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(request, cancellationToken));
        }
    }
}
