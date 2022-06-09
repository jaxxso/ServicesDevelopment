﻿using Microsoft.EntityFrameworkCore;
using ReminderApi.Domain.Common;
using ReminderApi.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Infrastructure.Common
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appDbContext.Set<T>().Where(predicate).ToListAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync<T>();
        }

        public async Task<T> GetByAsyncId(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entitiesToRemove)
        {
            _appDbContext.Set<T>().RemoveRange(entitiesToRemove);
            await _appDbContext.SaveChangesAsync();
        }

    }
}