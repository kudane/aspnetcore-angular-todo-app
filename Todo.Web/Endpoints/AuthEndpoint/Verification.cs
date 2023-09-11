using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using static Todo.Core.Features.AuthFeature.Verification;

namespace Todo.Web.Controllers.TodoEndpoint
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/Auth")]
    public class Verification : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<User>
    {
        private readonly IMediator mediator;

        public Verification(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("VerificationUser")]
        public override async Task<ActionResult<User>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await mediator.Send(new VerificationCommand(), cancellationToken));
        }
    }
}
