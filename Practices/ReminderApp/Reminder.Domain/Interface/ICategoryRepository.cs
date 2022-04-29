using Reminder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task AddAsync(Category entity);
        Task<IEnumerable<Category>> GetAllAsync();
        Task RemoveAsync(object category);
    }
}
