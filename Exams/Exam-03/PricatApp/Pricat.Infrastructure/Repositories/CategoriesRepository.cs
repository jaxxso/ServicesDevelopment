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
    public class CategoriesRepository : Repository<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }
    }
}
