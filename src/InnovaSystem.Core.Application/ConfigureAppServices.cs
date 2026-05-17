using FluentValidation;
using InnovaSystem.Core.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InnovaSystem.Core.Application
{
    public static class ConfigureAppServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(
                    Assembly.GetExecutingAssembly());
            });

            // FluentValidation
            services.AddValidatorsFromAssembly(
                Assembly.GetExecutingAssembly());


            /*BEHAVIORS*/
             services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            ////services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            ////services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            ///
            return services;
        }
    }
}
