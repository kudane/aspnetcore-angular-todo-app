using System.Collections.Generic;
using System.Security.Claims;

namespace Todo.Core.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(List<Claim> claims);
    }
}