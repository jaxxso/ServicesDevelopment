using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.Common
{
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetById(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Update(T entity);

        void Remove(T entity);

    }
}
