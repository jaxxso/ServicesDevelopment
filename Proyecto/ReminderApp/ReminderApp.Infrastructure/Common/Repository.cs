using Microsoft.EntityFrameworkCore;
using ReminderApp.Domain.Common;
using ReminderApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Common
{

    public class Repository<T> : IRepository<T> where T : EntityBase
    {

        private readonly AppDBContext _appDBContext;
        public Repository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void add(T entity)
        {
            _appDBContext.Set<T>().Add(entity);
            _appDBContext.SaveChanges();
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _appDBContext.Set<T>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return _appDBContext.Set<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            return _appDBContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _appDBContext.Set<T>().Remove(entity);
            _appDBContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _appDBContext.Entry(entity).State = EntityState.Modified;
            _appDBContext.SaveChanges();
        }
    }
}
