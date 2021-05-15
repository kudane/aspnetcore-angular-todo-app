using Ardalis.Specification;
using System.Linq;
using Todo.Core.Entities;

namespace Todo.Core.Specifications.UserSpec
{
    public class UserByUsernameSpec : Specification<User>, ISingleResultSpecification
    {
        public UserByUsernameSpec(string username)
        {
            Query.Where(a => a.Username == username);
        }
    }
}
