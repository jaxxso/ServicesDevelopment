using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Interfaces;
using ReminderApp.Domain.Entities;
using System.Threading.Tasks;

namespace ReminderApp.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        private readonly ICategoryService _categoryService;

        public ReminderController(IReminderService reminderService, ICategoryService categoryService)
        {
            _reminderService = reminderService;
            _categoryService = categoryService;
        }

        // GET: api/<ReminderController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reminderService.GetAllAsync());
        }

        // GET api/<ReminderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _reminderService.GetByIdAsync(id));
        }

        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {   
            return Ok(await _reminderService.GetAllByCategoryId(id));
        }

        // POST api/<ReminderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reminder person)
        {
            await _reminderService.AddAsync(person);
            return Ok();
        }

        // PUT api/<ReminderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reminder person)
        {
            await _reminderService.UpdateAsync(id, person);
            return Ok();
        }

        // DELETE api/<ReminderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.RemoveAsync(id);
            return Ok();
        }

        // DELETE api/<ReminderController>/Category/5
        [HttpDelete("Category/{id}")]
        public async Task<IActionResult> DeleteAllByCategoryId(int id)
        {
            await _categoryService.RemoveAsync(id);
            return Ok();
        }
    }
}