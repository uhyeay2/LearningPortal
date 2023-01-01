global using LearningPortal.Mediator.Abstractions.Mediation;
global using LearningPortal.Mediator.Abstractions.Requests;
global using LearningPortal.Mediator.Abstractions.Responses;
global using LearningPortal.Data.Abstractions.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using MediatR;
using System.Reflection;
using LearningPortal.Domain.Interfaces;

[assembly: InternalsVisibleTo("LearningPortal.Mediator.Tests")]
namespace LearningPortal.Mediator.Configurations
{
    public static class MediatorInjection
    {
        public static IServiceCollection InjectMediator(this IServiceCollection services)
        {
            services.AddSingleton<IDataConfig, LearningPortalDataConfig>();
            services.AddSingleton<IDbConnectionFactory, Data.DbConnectionFactory>();
            services.AddSingleton<IDataConnection, Data.DataConnection>();

            // Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
