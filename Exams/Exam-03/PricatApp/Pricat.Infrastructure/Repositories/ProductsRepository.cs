using Pricat.Domain.Entities;
using Pricat.Domain.Interfaces.Repositories;
using Pricat.Infrastructure.Common;
using Pricat.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricat.Infrastructure.Repositories
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        public ProductsRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public Task<IEnumerable<Products>> FindProductsCategory(int id)
        {
            return (Task<IEnumerable<Products>>)base.FindAsync(c => c.CategoryId.Equals(id));    
        }


    }
} 
