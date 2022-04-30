using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Interfaces.Repositories;
using ReminderApp.Infrastructure.Common;
using ReminderApp.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Repositories
{
   public class ReminderRepository : Repository<Reminder>, IReminderRepository
   {
      public ReminderRepository(AppDbContext appDbContext) : base(appDbContext)
      {
      }

        public async Task<IEnumerable<Reminder>> GetAllRemindersByCategoryId(int id)
        {
            return await FindAsync(r => r.CategoryId == id);
        }

        public async Task DeleteAllRemindersByCategoryId(int id)
        {
            var categoriesDelete = await GetAllRemindersByCategoryId(id);
            foreach(var category in categoriesDelete)
            {
                await RemoveAsync(category);
            }
        }

    }
}