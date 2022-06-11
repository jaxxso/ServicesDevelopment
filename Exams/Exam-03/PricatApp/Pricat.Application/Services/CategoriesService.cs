using Pricat.Application.Interfaces;
using Pricat.Domain.Entities;
using Pricat.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pricat.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _CategoriesRepository;

        public CategoriesService(ICategoriesRepository CategoriesRepository)
        {
            _CategoriesRepository = CategoriesRepository;
        }

        public async Task AddAsync(Categories entity)
        {
            await _CategoriesRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Categories>> FindAsync(Expression<Func<Categories, bool>> predicate)
        {
            return await _CategoriesRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await _CategoriesRepository.GetAllAsync();
        }

        public async Task<Categories> GetByIdAsync(int id)
        {
            var person = await _CategoriesRepository.GetByIdAsync(id);

            // Validte If Exist
            return person;
        }

        public async Task RemoveAsync(int id)
        {

            var person = await _CategoriesRepository.GetByIdAsync(id);
            await _CategoriesRepository.RemoveAsync(person);

        }

        public async Task UpdateAsync(int id, Categories entity)
        {
            // Validate if Exist
            await _CategoriesRepository.UpdateAsync(entity);

        }

        public bool ExistById(int id)
        {
            return _CategoriesRepository.Exist(id);
        }
    }
}
