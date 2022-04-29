using Reminder.Application.Interfaces;
using Reminder.Domain.Entities;
using Reminder.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Reminder.Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _personRepository;

        public CategoryService(ICategoryRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task AddAsync(Category entity)
        {
            await _personRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _personRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            // Validte If Exist
            return person;
        }

        public async Task RemoveAsync(int id)
        {
            var category = await _personRepository.GetByIdAsync(id);
            await _personRepository.RemoveAsync(category);
        }

        public async Task UpdateAsync(int id, Category entity)
        {
            // Validate if Exist
            await _personRepository.UpdateAsync(entity);
        }
    }
}
