using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Todo.Core
{
    public static class StartupSetup
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
