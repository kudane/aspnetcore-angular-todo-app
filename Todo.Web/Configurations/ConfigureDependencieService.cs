using Microsoft.Extensions.DependencyInjection;
using Todo.Core;
using Todo.Infrastructure;

namespace Todo.Web.Configurations
{
    public static class ConfigureDependencieService
    {
        public static void AddDependencieService(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            services.AddCoreServices();
        }
    }
}
