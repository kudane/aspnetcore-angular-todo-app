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
    public class AddTodo
    {
        public class AddTodoCommand : IRequest<TodoItem>
        {
            public string Title { get; set; }
        }

        public class Handler : IRequestHandler<AddTodoCommand, TodoItem>
        {
            private readonly IRepository<TodoItem> todoRepository;

            public Handler(IRepository<TodoItem> todoRepository)
            {
                this.todoRepository = todoRepository;
            }

            public async Task<TodoItem> Handle(AddTodoCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.Title)) 
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Invalid Title." });
                }

                var todo = new TodoItem
                {
                    Title = request.Title
                };

                await todoRepository.AddAsync(todo, cancellationToken);

                return todo;
            }
        }
    }
}
