using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Domain.Common
{
    public interface IRepository<T> where T : EntityBase
    {
        void add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);                           
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Remove(T entity);
    }
}
