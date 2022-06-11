using Pricat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pricat.Application.Interfaces
{
    public interface IProductsService
    {
        public Task AddAsync(Products entity);

        public Task<IEnumerable<Products>> GetAllAsync();

        public Task<Products> GetByIdAsync(int id);

        public Task<IEnumerable<Products>> FindAsync(Expression<Func<Products, bool>> predicate);

        public Task UpdateAsync(int id, Products entity);

        public Task RemoveAsync(int id);

        public bool ExistById(int id);

        public Task RemoveListAsync(int id);
        public Task<IEnumerable<Products>> GetAllByCategoryId(int id);
    }
}
