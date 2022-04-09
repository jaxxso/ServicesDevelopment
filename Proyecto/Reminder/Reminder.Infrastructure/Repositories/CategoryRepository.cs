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
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    
    }
}
