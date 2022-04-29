using Microsoft.EntityFrameworkCore;
using Reminder.Domain.Entities;


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
    }
}
