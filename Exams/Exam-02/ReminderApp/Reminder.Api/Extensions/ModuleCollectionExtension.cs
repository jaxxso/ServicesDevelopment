using Microsoft.Extensions.DependencyInjection;
using Reminder.Application.Interfaces;
using Reminder.Application.Services;
using Reminder.Domain.Interface;
using Reminder.Infrastructure.Repositories;

namespace Reminder.Api.Extensions
{
    public static class ModuleCollectionExtension
    {
        public static IServiceCollection AddCoreModules(this IServiceCollection services) 
        {
            // Service / Use Case
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IReminderService, ReminderService>();
            return services;

        }

        public static IServiceCollection AddInfrastructorModules(this IServiceCollection services) 
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IReminderRepository, ReminderRepository>();

            return services;
        }
    }
}
