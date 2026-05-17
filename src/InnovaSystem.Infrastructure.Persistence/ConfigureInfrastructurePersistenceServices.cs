using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnovaSystem.Infrastructure.Persistence
{
    public static class ConfigureInfrastructurePersistenceServices
    {
        /// <summary>
        /// Método para inyectar configuración de DB y repositorios
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddInfrastructurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IUserRepository, IUserTwoFactorRecoveryCodeStore() >;
        }
    }
}
