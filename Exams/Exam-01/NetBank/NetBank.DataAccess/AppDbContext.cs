using Microsoft.EntityFrameworkCore;
using NetBank.Models;

namespace NetBank.DataAccess
{
   public class AppDbContext : DbContext
   {
      public AppDbContext()
      {
      }

      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
      }

      public DbSet<ReportedCard> ReportedCards { get; set; }
   }
}