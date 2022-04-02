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
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
