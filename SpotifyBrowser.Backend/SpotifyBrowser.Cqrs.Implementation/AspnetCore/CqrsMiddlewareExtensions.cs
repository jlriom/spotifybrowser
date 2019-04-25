using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;

namespace SpotifyBrowser.Cqrs.Implementation.AspnetCore
{
    public static  class CqrsMiddlewareExtensions
    {
        public static void AddCqrs(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }
    }
}