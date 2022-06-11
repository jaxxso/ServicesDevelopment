using Pricat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pricat.Application.Interfaces
{
    public interface ICategoriesService
    {
        public Task AddAsync(Categories entity);

        public Task<IEnumerable<Categories>> GetAllAsync();

        public Task<Categories> GetByIdAsync(int id);

        public Task<IEnumerable<Categories>> FindAsync(Expression<Func<Categories, bool>> predicate);

        public Task UpdateAsync(int id, Categories entity);

        public bool ExistById(int id);

        public Task RemoveAsync(int id);
    }
}
