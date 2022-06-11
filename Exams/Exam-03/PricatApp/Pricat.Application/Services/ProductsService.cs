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
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _ProductsRepository;

        public ProductsService(IProductsRepository ProductsRepository)
        {
            _ProductsRepository = ProductsRepository;
        }

        public async Task AddAsync(Products entity)
        {
            await _ProductsRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Products>> FindAsync(Expression<Func<Products, bool>> predicate)
        {
            return await _ProductsRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _ProductsRepository.GetAllAsync();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            var person = await _ProductsRepository.GetByIdAsync(id);

            // Validte If Exist
            return person;
        }

        public async Task RemoveAsync(int id)
        {
            var person = await _ProductsRepository.GetByIdAsync(id);
            await _ProductsRepository.RemoveAsync(person);
        }

        public async Task RemoveListAsync(int id)
        {
            foreach (var item in await _ProductsRepository.FindProductsCategory(id))
            {
                await _ProductsRepository.RemoveAsync(item);
            }

        }

        public async Task UpdateAsync(int id, Products entity)
        {
            // Validate if Exist
            await _ProductsRepository.UpdateAsync(entity);
        }

        public Task<IEnumerable<Products>> GetAllByCategoryId(int id)
        {
            return _ProductsRepository.FindProductsCategory(id); 
        }

        public bool ExistById(int id)
        {
            return _ProductsRepository.Exist(id);
        }
    }
}
