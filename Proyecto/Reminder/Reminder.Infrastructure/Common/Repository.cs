using Microsoft.EntityFrameworkCore;
using Reminder.Domain.Common;
using Reminder.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Infrastructure.Common
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(T entity)
        {
            /*
                Instruccion de EntityFrameworkCore para agregar un dato de tipo T en el conjunto de datos
                que corresponda al tipo T guardado en el DbSet del objeto AppDbContext
             */
            _appDbContext.Set<T>().Add(entity);
            //Instruccion de EntityFrameworkCore para guardar los cambios en el DbSet del objeto AppDbContext
            _appDbContext.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            /*
                Instruccion de EntityFrameworkCore para buscar un dato que cumpla con la expresion dada
                en el conjunto de datos que corresponda al tipo T guardado en el DbSet del objeto AppDbContext
            */
            return _appDbContext.Set<T>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            /*
                Instruccion de EntityFrameworkCore en el que convierte el conjunto de datos de tipo T en
                una coleccion de datos
            */
            return _appDbContext.Set<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            /*
                Instruccion de EntityFrameworkCore para buscar un dato de tipo T por el atributo Id 
                en el conjunto de datos que corresponda al tipo T guardado en el DbSet del objeto AppDbContext
            */
            return _appDbContext.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            /*
                Instruccion de EntityFrameworkCore para eliminar un dato de tipo T en el conjunto de datos
                que corresponda al tipo T guardado en el DbSet del objeto AppDbContext
            */
            _appDbContext.Set<T>().Remove(entity);
            //Instruccion de EntityFrameworkCore para guardar los cambios en el DbSet del objeto AppDbContext
            _appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            /*
                Instruccion de EntityFrameworkCore para agregar un dato de tipo T en el conjunto de datos
                que corresponda al tipo T guardado en el DbSet del objeto AppDbContext
            */
            _appDbContext.Entry(entity).State = EntityState.Modified;
            //Instruccion de EntityFrameworkCore para guardar los cambios en el DbSet del objeto AppDbContext
            _appDbContext.SaveChanges();
        }
    }
}
