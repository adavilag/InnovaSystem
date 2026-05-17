using System.Reflection;

namespace InnovaSystem.WebApi.Extensions
{
    public static class ConfigureServices
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            // services.AddAuthentication(...);
        }
    }
}
