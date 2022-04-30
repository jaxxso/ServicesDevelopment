using Microsoft.AspNetCore.Mvc;
using ReminderAPP.Application.Interfaces;
using ReminderAPP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReminderAPP.Api.Controllers;
using System.Linq.Expressions;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReminderAPP.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        private readonly ICategoryService _categoryService;
        public RemindersController(IReminderService reminderService, ICategoryService categoryService)
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

        // POST api/<PeopleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reminder reminders)
        {
            await _reminderService.AddAsync(reminders);
            return Ok();
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reminder reminders)
        {
            await _reminderService.UpdateAsync(id, reminders);
            return Ok();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.RemoveAsync(id);
            return Ok();
        }




    }
}
