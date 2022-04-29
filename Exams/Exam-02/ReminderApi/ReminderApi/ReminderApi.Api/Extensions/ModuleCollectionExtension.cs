using Microsoft.Extensions.DependencyInjection;
using ReminderApi.Application.Interfaces;
using ReminderApi.Application.Services;
using ReminderApi.Domain.Interfaces.Repositories;
using ReminderApi.Infrastructure.Repositories;

namespace ReminderApi.Api.Extensions
{
    public static class ModuleCollectionExtension
    {
        public static IServiceCollection AddCoreModules(this IServiceCollection services)
        {
            // Services / Use Cases
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IReminderService, ReminderService>();

            return services;
        }

        public static IServiceCollection AddInfrastructureModules(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReminderRepository, ReminderRepository>();


            return services;
        }
    }
}
