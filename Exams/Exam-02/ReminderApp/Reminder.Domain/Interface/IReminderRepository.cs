using Reminder.Domain.Interface;
using Reminder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Infrastructure.Common;

namespace Reminder.Domain.Interface
{
    public interface IReminderRepository : IRepository<ReminderApp>
    {
        Task AddAsync(ReminderApp entity);
    }
}
