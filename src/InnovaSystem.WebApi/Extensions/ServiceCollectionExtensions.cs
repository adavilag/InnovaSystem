using InnovaSystem.Core.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InnovaSystem.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureApplication(this IServiceCollection services)
        {

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            ////services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            ////services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }

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
