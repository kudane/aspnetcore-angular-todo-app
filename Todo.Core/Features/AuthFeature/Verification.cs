using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Exceptions;
using Todo.Core.Interfaces;

namespace Todo.Core.Features.AuthFeature
{
    public class Verification
    {
        public class VerificationCommand : IRequest<User> { }

        public class Handler : IRequestHandler<VerificationCommand, User>
        {
            private readonly IRepository<User> userRepository;
            private readonly ICurrentUserAccessor currentUserAccessor;

            public Handler(IRepository<User> userRepository, ICurrentUserAccessor currentUserAccessor)
            {
                this.userRepository = userRepository;
                this.currentUserAccessor = currentUserAccessor;
            }

            public async Task<User> Handle(VerificationCommand request, CancellationToken cancellationToken)
            {
                var userId = currentUserAccessor.GetCurrentUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    throw new RestException(HttpStatusCode.Unauthorized, new { Error = "Unknown User Unauthorized" });
                }

                var user = await userRepository.GetByIdAsync(userId, cancellationToken);

                if (user == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized, new { Error = $"Invalid UserId {userId}" });
                }

                return user;
            }
        }
    }
}
