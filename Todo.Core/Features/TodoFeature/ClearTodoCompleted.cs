using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Core.Specifications.TodoSpec;

namespace Todo.Core.Features.TodoFeature
{
    public class ClearTodoCompleted
    {
        public class ClearTodoCompleteCommand : IRequest { }

        public class Handler : AsyncRequestHandler<ClearTodoCompleteCommand>
        {
            private readonly IRepository<TodoItem> todoRepository;

            public Handler(IRepository<TodoItem> todoRepository)
            {
                this.todoRepository = todoRepository;
            }

            protected override async Task Handle(ClearTodoCompleteCommand request, CancellationToken cancellationToken)
            {
                var todos = await todoRepository.ListAsync(new TodoCompleteSpec(), cancellationToken);

                await todoRepository.DeleteRangeAsync(todos, cancellationToken);
            }
        }
    }
}
