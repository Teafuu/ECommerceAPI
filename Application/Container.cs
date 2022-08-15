using System.Reflection;
using Application.Commands.V1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Container
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
