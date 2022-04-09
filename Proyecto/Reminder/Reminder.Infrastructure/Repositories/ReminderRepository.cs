using Reminder.Domain.Entities;
using Reminder.Infrastructure.Common;
using Reminder.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Infrastructure.Repositories
{
    public class ReminderRepository : Repository<Reminder.Domain.Entities.Reminder>
    {
        public ReminderRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public IEnumerable<Reminder.Domain.Entities.Reminder> FindRemindersByCategory(Category category)
        {
            return base.Find(c => c.Category.Equals(category));
        }
    }
}
