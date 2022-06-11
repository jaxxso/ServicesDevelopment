using Microsoft.AspNetCore.Mvc;
using Pricat.Application.Interfaces;
using Pricat.Domain.Entities;
using System.Threading.Tasks;
using Pricat.Utilities;

namespace Pricat.Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _ProductsService;

        public ProductsController(IProductsService ProductsService)
        {
            _ProductsService = ProductsService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _ProductsService.GetAllAsync());

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            if (_ProductsService.ExistById(id))
            {
                return Ok(await _ProductsService.GetByIdAsync(id));
            }
            return NotFound($"404 - Not Found: El Id ingresado no existe");
            
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId)
        {
            return Ok(await _ProductsService.GetAllByCategoryId(categoryId));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Products person)
        {

            if (Ean13Calculator.IsValid(person.EanCode))
            {
                if (person.id > 0)
                {
                    await _ProductsService.AddAsync(person);
                    return Ok("200 - OK: Success Response");
                }
                else
                {
                   return NotFound($"404 - Not Found: El Id ingresado no es valido");
                }
            }
            return BadRequest("El EAN Code ingresado no es valido");
            
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Products person)
        {

            if (!_ProductsService.ExistById(id))
            {
                return NotFound($"404 - Not Found: El Id ingresado no existe");
            }

            if (id != person.id)
            {
                return BadRequest($"El id de la nueva entrada no coincide con el id de la categoria ");
            }
            if (Ean13Calculator.IsValid(person.EanCode))
            {
                await _ProductsService.UpdateAsync(id, person);
                return Ok("200 - OK: Success Response");
            }
             return BadRequest("El EAN Code ingresado no es valido");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_ProductsService.ExistById(id))
            {
                await _ProductsService.RemoveAsync(id);
                return Ok("200 - OK: Success Response");
            }
            return NotFound($"404 - Not Found: El Id ingresado no existe");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("Category/{id}")]
        public async Task<IActionResult> DeleteByCategory(int id)
        {

           await _ProductsService.RemoveListAsync(id);
           return Ok("200 - OK: Success Response");
        }

    }
}