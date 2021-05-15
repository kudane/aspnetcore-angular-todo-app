using Ardalis.Specification;
using Todo.Core.Entities;

namespace Todo.Core.Specifications.TodoSpec
{
    public class TodoCompleteSpec: Specification<TodoItem>
    {
        public TodoCompleteSpec()
        {
            Query.Where(a => a.Completed);
        }
    }
}
