using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Exceptions;
using Todo.Core.Interfaces;
using Todo.Core.Specifications.UserSpec;

namespace Todo.Core.Features.AuthFeature
{
    public class Signin
    {
        public class SigninCommand : IRequest<SigninResponse>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class SigninResponse
        {
            public string Token { get; set; }
            public User User { get; set; }
        }

        public class Handler : IRequestHandler<SigninCommand, SigninResponse>
        {
            private readonly IRepository<User> userRepository;
            private readonly IJwtTokenGenerator jwtTokenGenerator;

            public Handler(IRepository<User> userRepository, IJwtTokenGenerator jwtTokenGenerator)
            {
                this.userRepository = userRepository;
                this.jwtTokenGenerator = jwtTokenGenerator;
            }

            public async Task<SigninResponse> Handle(SigninCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Invalid Username Or Password." });
                }

                var user = await userRepository.GetBySpecAsync(new UserByUsernameSpec(request.Username), cancellationToken);

                if (user == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Error = $"User:{request.Username} Not Found" });
                }

                if (user.Password != request.Password)
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Invalid Username Or Password." });
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Demo Role 1"),
                    new Claim(ClaimTypes.Role, "Demo Role 2")
                };

                var token = jwtTokenGenerator.CreateToken(claims);

                return new SigninResponse
                {
                    Token = token,
                    User = user
                };
            }
        }
    }
}
