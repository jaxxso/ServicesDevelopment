using Microsoft.EntityFrameworkCore;
using ReminderApi.Domain.Common;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

    }
}
