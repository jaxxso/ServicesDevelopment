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

        public Task DeleteAllRemindersByCategoryId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByCategoryId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Reminder>> getAllByCategoryId(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Reminder>> GetAllByCategoryIdAsync(int id)
        {
            return await FindAsync(r => r.Id == id);
        }

        public async Task RemoveAllByCategoryIdAsync(int id)
        {
            var remindersToRemove = await GetAllByCategoryIdAsync(id);
            await RemoveRangeAsync(remindersToRemove);
        }

        private Task RemoveRangeAsync(IEnumerable<Reminder> remindersToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
