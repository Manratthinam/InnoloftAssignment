using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    public static class ConfigurationSetting
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
