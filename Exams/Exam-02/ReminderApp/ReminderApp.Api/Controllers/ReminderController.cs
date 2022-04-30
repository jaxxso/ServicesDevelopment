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
    [Route("api/v1/reminder")]
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

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reminderService.GetAllAsync());
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _reminderService.GetByIdAsync(id));
        }

        // POST api/<ReminderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reminder reminder)
        {
            await _reminderService.AddAsync(reminder);
            return Ok();
        }

        // PUT api/<ReminderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reminder reminder)
        {
            await _reminderService.UpdateAsync(id, reminder);
            return Ok();
        }

        // DELETE api/<ReminderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.RemoveAsync(id);
            return Ok();
        }

        [HttpGet("categoy/{id}")]
        public async Task<IEnumerable<Reminder>> GetAllRemindersByCategoryId(int id)
        {
            return await _reminderService.GetAllRemindersByCategoryId(id);
        }

        [HttpDelete("category/{id}")]
        public async Task DeleteAllRemindersByCategoryId(int id)
        {
            await _reminderService.DeleteAllRemindersByCategoryId(id);
        }
    }
}

