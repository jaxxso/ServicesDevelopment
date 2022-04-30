using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReminderApi.Api.Models;
using ReminderApi.Application.Interfaces;
using ReminderApi.Domain.Entities;
using ReminderApi.Infrastructure.Context;

namespace ReminderApi.Api.Controllers
{
    [Route("api/v1/reminder")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly IReminderService _reminderService;

        public RemindersController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        // GET: api/v1/<RemindersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reminderService.GetAllAsync());
        }

        // GET api/v1/<RemindersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _reminderService.GetByAsyncId(id));
        }

        // GET api/v1/<RemindersController>/category/5
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(await _reminderService.GetAllByCategoryIdAsync(id));
        }

        // DELETE api/v1/<RemindersController>/category/5
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteAllByCategoryId(int id)
        {
            await _reminderService.RemoveAllByCategoryIdAsync(id);
            return Ok();
        }

        // POST api/v1/<RemindersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReminderEntry reminder)
        {
            await _reminderService.AddAsync(ReminderEntryToReminder(reminder));
            return Ok();
        }

        // PUT api/v1/<RemindersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReminderEntry reminder)
        {
            await _reminderService.UpdateAsync(id, ReminderEntryToReminder(reminder));
            return Ok();
        }

        // DELETE api/v1/<RemindersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reminderService.RemoveAsync(id);
            return Ok();
        }

        private Reminder ReminderEntryToReminder(ReminderEntry reminderEntry)
        {
            Reminder reminder = new Reminder();
            reminder.Id = reminderEntry.Id;
            reminder.CategoryId = reminderEntry.CategoryId;
            reminder.Description = reminderEntry.Description;
            reminder.StartDate = reminderEntry.StartDate;
            reminder.CronExpression = reminderEntry.CronExpression;
            reminder.NumberOfTimes = reminderEntry.NumberOfTimes;
            reminder.Enabled = reminderEntry.Enabled;
            return reminder;
        }
    }
}
