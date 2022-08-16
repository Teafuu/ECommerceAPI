using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services;
using Application.Services.HttpClients;
using Application.Services.Interfaces;
using Microsoft.Extensions.Http;

namespace Application
{
    public static class Container
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<PaymentService>();
            services.AddHttpClient<IPaymentHttpClient, MockPaymentHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://somemockpaymentapi");
            });
            
            return services;
        }
    }
}
