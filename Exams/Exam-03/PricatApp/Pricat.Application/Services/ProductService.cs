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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _productRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;
            return product;
        }

        public async Task RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null) await _productRepository.RemoveAsync(product);
        }

        public async Task UpdateAsync(int id, Product entity)
        {
            await _productRepository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Product>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _productRepository.GetAllByCategoryIdAsync(categoryId);
        }

        public async Task RemoveAllByCategoryIdAsync(int categoryId)
        {
            await _productRepository.RemoveAllByCategoryIdAsync(categoryId);
        }

        public async Task GenerateEanCode()
        {
            var products = await _productRepository.GetAllAsync();
        }

    }
}