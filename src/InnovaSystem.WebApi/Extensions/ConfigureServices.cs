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
        

        /// <summary>
        /// Método para inyectar configuración de DB y repositoriso
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IUserRepository, IUserTwoFactorRecoveryCodeStore() >;
        }


        public static void ConfigureIdentity(this IServiceCollection services)
        {
            // services.AddAuthentication(...);
        }
    }
}
