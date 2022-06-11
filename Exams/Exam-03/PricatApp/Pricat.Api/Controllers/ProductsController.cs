using Microsoft.AspNetCore.Mvc;
using Pricat.Application.Interfaces;
using Pricat.Application.Exceptions;
using Pricat.Domain.Entities;
using Pricat.Utilities;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pricat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;


        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productService.GetAllAsync());
            } catch (Exception)
            {
                throw;
            }
        }

        // GET api/v1/<ProductsController>/category/5
        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            try
            {
                if (await CategoryExist(id) != true) throw new NotFoundException($"No se encontro la categoria con el id {id}");
                return Ok(await _productService.GetAllByCategoryIdAsync(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                if (product == null) throw new NotFoundException($"El id '{id}' no existe");
                return Ok(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                if (Ean13Calculator.IsValid(product.EanCode))
                {
                    await _productService.AddAsync(product);

                    if (await CategoryExist(product.CategoryId) == true) 
                    {
                        return Ok(product);
                    }
                    throw new NotFoundException($"No se encontro la categoria con el id {product.CategoryId}");
                }
                throw new BadRequestException("El código EAN no es valido");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/v1/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    throw new BadRequestException($"Los id no coinciden: {id} != {product.Id}");
                }
                else if (Ean13Calculator.IsValid(product.EanCode))
                {
                    if (await CategoryExist(product.CategoryId) == true)
                    {
                        await _productService.UpdateAsync(id, product);
                        return Ok();
                    }
                    throw new NotFoundException($"No se encontro la categoria con el id {product.CategoryId}");
                }
                throw new BadRequestException("El código EAN no es valido");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/v1/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await ProductExist(id))
                {
                    await _productService.RemoveAsync(id);
                    return Ok();
                }
                throw new NotFoundException($"El id '{id}' no existe");
            }
            catch (Exception)
            {
                throw;
            }   
        }

        // DELETE api/v1/<ProductsController>/category/5
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteAllByCategoryId(int id)
        {
            try
            {
                await _productService.RemoveAllByCategoryIdAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> ProductExist(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product != null) return true;
            return false;
        }

        private async Task<bool> CategoryExist(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return false;
            return true;
        }
    }
}
