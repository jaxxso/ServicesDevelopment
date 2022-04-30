using Microsoft.EntityFrameworkCore;
using ReminderApi.Domain.Entities;
using ReminderApi.Domain.Interfaces.Repositories;
using ReminderApi.Infrastructure.Common;
using ReminderApi.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Infrastructure.Repositories
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

