using ReminderApi.Application.Interfaces;
using ReminderApi.Domain.Entities;
using ReminderApi.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReminderApi.Application.Services
{
   public class CategoryService : ICategoryService
   {
      private readonly ICategoryRepository _categoryRepository;
      private readonly IReminderRepository _reminderRepository;

      public CategoryService(ICategoryRepository categoryRepository, IReminderRepository reminderRepository)
      {
         _categoryRepository = categoryRepository;
         _reminderRepository = reminderRepository;
      }

      public async Task AddAsync(Category entity)
      {
         await _categoryRepository.AddAsync(entity);
      }

      public async Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
      {
         return await _categoryRepository.FindAsync(predicate);
      }

      public async Task<IEnumerable<Category>> GetAllAsync()
      {
         return await _categoryRepository.GetAllAsync();
      }

      public async Task<Category> GetByAsyncId(int id)
      {
         var category = await _categoryRepository.GetByAsyncId(id);
         if (category == null) return null;
         return category;
      }

      public async Task RemoveAsync(int id)
      {
         var category = await _categoryRepository.GetByAsyncId(id);
         if (category != null)
         {
            await _reminderRepository.RemoveAllByCategoryIdAsync(id);
            await _categoryRepository.RemoveAsync(category);
         }
               
      }

      public async Task UpdateAsync(int id, Category entity)
      {
         await _categoryRepository.UpdateAsync(entity);
      }
   }
}