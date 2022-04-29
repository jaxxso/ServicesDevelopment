using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Interfaces;
using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReminderApp.Api.Controllers
{
    [Route("api/[controller]")]
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

        // POST api/<ReminderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reminder person)
        {
            await _reminderService.AddAsync(person);
            return Ok();
        }

        // GET api/<ReminderController>/ByCategory/5
        [HttpGet("ByCategory/{id}")]
        public async Task<IActionResult> Find(Expression<Func<Reminder, bool>> predicate)
        {
            return Ok(await _reminderService.FindAsync(predicate));
        }

        // GET api/<ReminderController>/ByCategory/5
        [HttpGet("ByCategoryId/{id}")]
        public async Task<IActionResult> FindByCategoryId(int id)
        {
            return Ok(await _reminderService.FindIdAsync(id));
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

        // DELETE api/<PeopleController>/Category/5
        [HttpDelete("Category/{id}")]
        public async Task<IActionResult> DeleteByategoryId(int id)
        {
            await _categoryService.RemoveAsync(id);
            return Ok();
        }
    }
}
