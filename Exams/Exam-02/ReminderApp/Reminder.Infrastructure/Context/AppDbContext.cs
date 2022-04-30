using Microsoft.EntityFrameworkCore;
using Reminder.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Reminder.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ReminderApp> Reminder { get; set; }

        public Task<object> GetAllByCategoryIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllByCategoryIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
