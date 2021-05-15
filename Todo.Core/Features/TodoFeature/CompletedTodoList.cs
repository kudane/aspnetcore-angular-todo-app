using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Core.Specifications.TodoSpec;

namespace Todo.Core.Features.TodoFeature
{
    public class CompletedTodoList
    {
        public class CompleteTodoListCommand : IRequest<IEnumerable<TodoItem>> { }

        public class Handler : IRequestHandler<CompleteTodoListCommand, IEnumerable<TodoItem>>
        {
            private readonly IRepository<TodoItem> todoRepository;

            public Handler(IRepository<TodoItem> todoRepository)
            {
                this.todoRepository = todoRepository;
            }

            public async Task<IEnumerable<TodoItem>> Handle(CompleteTodoListCommand request, CancellationToken cancellationToken)
            {
                return await todoRepository.ListAsync(new TodoCompleteSpec(), cancellationToken);
            }
        }
    }
}
