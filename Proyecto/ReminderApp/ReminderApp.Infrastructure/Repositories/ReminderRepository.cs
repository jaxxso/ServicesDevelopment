using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Interfaces.Repositories;
using ReminderApp.Infrastructure.Common;
using ReminderApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Repositories
{
    public class ReminderRepository : Repository<Reminder>, IReminderRepository
    {
        public ReminderRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public Task<IEnumerable<Reminder>> FindReminderCategory(int id)
        {
            return (Task<IEnumerable<Reminder>>)base.FindAsync(c => c.CategoryId.Equals(id));    
        }
    }
} 
