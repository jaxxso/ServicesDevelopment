using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReminderApi.Application.Interfaces;
using ReminderApi.Domain.Entities;
using ReminderApi.Infrastructure.Context;

namespace ReminderApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public RemindersController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        // GET: api/<RemindersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reminderService.GetAllAsync());
        }

        // GET api/<RemindersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _reminderService.GetByAsyncId(id));
        }

        // GET api/<RemindersController>/category/5
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(await _reminderService.GetAllByCategoryIdAsync(id));
        }

        // DELETE api/<RemindersController>/category/5
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteAllByCategoryId(int id)
        {
            await _reminderService.RemoveAllByCategoryIdAsync(id);
            return Ok();
        }

        // POST api/<RemindersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reminder reminder)
        {
            await _reminderService.AddAsync(reminder);
            return Ok();
        }

        // PUT api/<RemindersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reminder reminder)
        {
            await _reminderService.UpdateAsync(id, reminder);
            return Ok();
        }

        // DELETE api/<RemindersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.RemoveAsync(id);
            return Ok();
        }
    }
}
