using Reminder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Application.Interfaces
{
    public interface IReminderService
    {
        Task AddAsync(ReminderApp entity);
        Task<IEnumerable<ReminderApp>> FindAsync(Expression<Func<ReminderApp, bool>> predicate);
        Task<IEnumerable<ReminderApp>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task UpdateAsync(ReminderApp entity);
    }
}
