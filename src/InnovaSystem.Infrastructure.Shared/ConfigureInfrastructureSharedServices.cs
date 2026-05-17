using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnovaSystem.Infrastructure.Shared
{
    public static class ConfigureInfrastructureSharedServices
    {
        /// <summary>
        /// Método para inyectar configuración de Servicios externos (Apis externos, soapclient, socket, etc)
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddInfrastructureSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IUserRepository, IUserTwoFactorRecoveryCodeStore() >;
        }
    }
}
