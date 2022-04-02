using Reminder.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Infrastructure.Repositories
{
    public class ReminderRepository: Repository<Reminder>
    {
        public ReminderRepository(AppDbContext appDbContext) : base(appDbContext)
        { }

        public IEnumerable<Reminder> FindRemiderByCategory(Category category)
        {
            return base.Find(c => c.CategoryEquals(category));
        }

    }
}
