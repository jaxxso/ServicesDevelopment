using ReminderApp.Domain.Entities;
using ReminderApp.Infrastructure.Common;
using ReminderApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Repositories
{
    public class ReminderRepository : Repository<Reminder>
    {
        public ReminderRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public IEnumerable<Reminder> FindReminderCategory(Category category)
        {
            return base.Find(c => c.Category.Equals(category));
        }
    }
} 
