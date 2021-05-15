using Ardalis.Specification;
using Todo.Core.Entities;

namespace Todo.Core.Specifications.TodoSpec
{
    public class TodoActiveSpec : Specification<TodoItem>
    {
        public TodoActiveSpec()
        {
            Query.Where(a => !a.Completed);
        }
    }
}
