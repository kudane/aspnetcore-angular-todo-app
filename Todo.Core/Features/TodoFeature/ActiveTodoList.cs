using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Core.Specifications.TodoSpec;

namespace Todo.Core.Features.TodoFeature
{
    public class ActiveTodoList
    {
        public class ActiveTodoListCommand : IRequest<IEnumerable<TodoItem>> { }

        public class Handler : IRequestHandler<ActiveTodoListCommand, IEnumerable<TodoItem>>
        {
            private readonly IRepository<TodoItem> todoRepository;

            public Handler(IRepository<TodoItem> todoRepository)
            {
                this.todoRepository = todoRepository;
            }

            public async Task<IEnumerable<TodoItem>> Handle(ActiveTodoListCommand request, CancellationToken cancellationToken)
            {
                return await todoRepository.ListAsync(new TodoActiveSpec(), cancellationToken);
            }
        }
    }
}
