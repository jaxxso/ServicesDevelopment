using Pricat.Domain.Common;
using Pricat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricat.Domain.Interfaces.Repositories
{
    public interface IProductsRepository : IRepository<Products>
    {
        public Task<IEnumerable<Products>> FindProductsCategory(int id);
    }
}