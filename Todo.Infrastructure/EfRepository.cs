using Ardalis.Specification.EntityFrameworkCore;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        public EfRepository(TodoDbContext context) : base(context) { }
    }
}
