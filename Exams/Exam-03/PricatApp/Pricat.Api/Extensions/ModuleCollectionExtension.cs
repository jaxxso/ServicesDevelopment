using Microsoft.Extensions.DependencyInjection;
using Pricat.Application.Interfaces;
using Pricat.Application.Services;
using Pricat.Domain.Interfaces.Repositories;
using Pricat.Infrastructure.Repositories;

namespace Pricat.Api.Extensions
{
    public static class ModuleCollectionExtension
    {
        public static IServiceCollection AddCoreModules(this IServiceCollection services)
        {
            // Services / Use Cases
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IProductsService, ProductsService>();

            return services;
        }

        public static IServiceCollection AddInfrastructureModules(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}