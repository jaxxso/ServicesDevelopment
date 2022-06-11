using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pricat.Application.Exceptions;
using Pricat.Application.Interfaces;
using Pricat.Domain.Entities;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pricat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _categoryService.GetAllAsync());
            } 
            catch (Exception)
            {
                throw;
            } 
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null) throw new NotFoundException($"El id '{id}' no existe");
                return Ok(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            try
            {
                await _categoryService.AddAsync(category);
                return Ok(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/v1/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                throw new BadRequestException($"No coinciden los id: '{id}' != {category.Id}");
            }
            if (await CategoryExist(id) == false) throw new NotFoundException($"No se encontro el id {id}");
            try
            {
                await _categoryService.UpdateAsync(id, category);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            
            }

        }

        // DELETE api/v1/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await CategoryExist(id) == false) throw new NotFoundException($"No se encontro el id {id}");
                await _categoryService.RemoveAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;

            }
        }

        private async Task<bool> CategoryExist(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return false;
            return true;
        }

    }
}
