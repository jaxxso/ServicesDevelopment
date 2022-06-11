using Microsoft.AspNetCore.Mvc;
using Pricat.Application.Interfaces;
using Pricat.Domain.Entities;
using System.Threading.Tasks;

namespace Pricat.Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _CategoriesService;
        private readonly IProductsService _ProductsService;
        public CategoriesController(ICategoriesService CategoriesService, IProductsService ProductsService)
        {
            _CategoriesService = CategoriesService;
            _ProductsService = ProductsService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            return Ok(await _CategoriesService.GetAllAsync());
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            if (_CategoriesService.ExistById(id))
            {
                
                return Ok(await _CategoriesService.GetByIdAsync(id));
            }
            return NotFound($"404 - Not Found: El Id ingresado no existe");
           
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categories person)
        {

            if (person.id>0)
            {
                await _CategoriesService.AddAsync(person);
                return Ok("200 - OK: Success Response");
            }
            return BadRequest("400 - Bad Request: Formato invalido");
                
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categories person)
        {

            if (!_CategoriesService.ExistById(id))
            {
                return NotFound($"404 - Not Found: El Id ingresado no existe");
            }
            
            if (id!= person.id)
            {
                return BadRequest($"El id de la nueva entrada no coincide con el id de la categoria ");
            }

            await _CategoriesService.UpdateAsync(id, person);
            return Ok("200 - OK: Success Response");

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (_CategoriesService.ExistById(id))
            {
                await _ProductsService.RemoveListAsync(id);
                await _CategoriesService.RemoveAsync(id);
                return Ok("200 - OK: Success Response");
            }
            return NotFound($"404 - Not Found: El Id ingresado no existe");
            

        }
    }
}
