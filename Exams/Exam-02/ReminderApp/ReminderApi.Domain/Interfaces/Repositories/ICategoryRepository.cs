using ReminderApi.Domain.Common;
using ReminderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
