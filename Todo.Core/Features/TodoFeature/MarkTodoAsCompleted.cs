using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Exceptions;
using Todo.Core.Interfaces;

namespace Todo.Core.Features.TodoFeature
{
    public class MarkTodoAsCompleted
    {
        public class MarkTodoAsCompleteCommand : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<MarkTodoAsCompleteCommand>
        {
            private readonly IRepository<TodoItem> todoRepository;

            public Handler(IRepository<TodoItem> todoRepository)
            {
                this.todoRepository = todoRepository;
            }

            protected override async Task Handle(MarkTodoAsCompleteCommand request, CancellationToken cancellationToken)
            {
                if (request.Id == Guid.Empty)
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Invalid Id Or Empty." });
                }

                var todo = await todoRepository.GetByIdAsync(request.Id, cancellationToken);

                if (todo == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Error = $"Todo:{request.Id} Not Found" });
                }
                else
                {
                    todo.MarkAsComplete();

                    await todoRepository.UpdateAsync(todo, cancellationToken);
                }

                return;
            }
        }
    }
}
