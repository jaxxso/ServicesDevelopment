using ReminderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Application.Interfaces
{
    public interface IReminderService
    {
        public Task AddAsync(Reminder entity);

        public Task<IEnumerable<Reminder>> GetAllAsync();

        public Task<Reminder> GetByAsyncId(int id); 

        public Task<IEnumerable<Reminder>> FindAsync(Expression<Func<Reminder, bool>> predicate);

        public Task UpdateAsync(int id, Reminder entity);

        public Task RemoveAsync(int id);

        public Task<IEnumerable<Reminder>> GetAllByCategoryIdAsync(int categoryId);

        public Task RemoveAllByCategoryIdAsync(int categoryId);
    }
}
