using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Todo.Core.Entities;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Security;

namespace Todo.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<TodoDbContext>();

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserAccessor, CurrentUserAccessor>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddScoped<IRepository<TodoItem>, EfRepository<TodoItem>>();
            services.AddScoped<IRepository<User>, EfRepository<User>>(); 
        }
    }
}
