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
        Task AddAsync(Domain.Entities.Reminder entity);
        Task<IEnumerable<Domain.Entities.Reminder>> FindAsync(Expression<Func<Domain.Entities.Reminder, bool>> predicate);
        Task<IEnumerable<Domain.Entities.Reminder>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task UpdateAsync(Domain.Entities.Reminder entity);
    }
}
