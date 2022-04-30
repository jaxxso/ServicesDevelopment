using ReminderAPP.Domain.Entities;
using ReminderAPP.Domain.Interface.Repositories;
using ReminderAPP.Infrastructure.Common;
using ReminderAPP.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReminderAPP.Infrastructure.Repositories
{
    public class ReminderRepository : Repository<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Reminder>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await FindAsync(r => r.CategoryId == categoryId);
        }

        public async Task RemoveAllByCategoryIdAsync(int categoryId)
        {
            var remindersToRemove = await GetAllByCategoryIdAsync(categoryId);
            await RemoveRangeAsync(remindersToRemove);
        }
    }


}
