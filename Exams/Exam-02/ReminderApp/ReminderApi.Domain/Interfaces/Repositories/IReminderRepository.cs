using ReminderApi.Domain.Common;
using ReminderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Domain.Interfaces.Repositories
{
    public interface IReminderRepository : IRepository<Reminder>
    {
        public Task<IEnumerable<Reminder>> GetAllByCategoryIdAsync(int categoryId);

        public Task RemoveAllByCategoryIdAsync(int categoryId);
    }

}
