using Ardalis.Specification;

namespace Todo.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T>, IReadRepositoryBase<T> where T : class
    {
    }
}
