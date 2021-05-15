using Microsoft.Extensions.DependencyInjection;
using Todo.Web.Filters;

namespace Todo.Web.Configurations
{
    public static class ConfigureControllerAndFilterService
    {
        public static void AddControllerAndFilterService(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            });
        }
    }
}
