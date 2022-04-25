﻿using Reminder.Domain.Entities;
using Reminder.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Infrastructure.Repositories
{

    public class CategotyRepository : Repository<Category>
    {
        public CategotyRepository(AppDbContext appDbContext) : base(appDbContext)
        { 
        }
    }
}
