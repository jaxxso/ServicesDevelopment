using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Context;
using Application.Interfaces;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IReminderService _reminderService;
        public RemindersController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        // GET: api/Reminders
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _reminderService.GetAllAsync());
        }

        // GET: api/Reminders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reminder>> GetReminder(int id)
        {
            var reminder = await _reminderService.GetByIdAsync(id);

            if (reminder == null)
            {
                return NotFound();
            }

            return reminder;
        }

        // PUT: api/Reminders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminder(int id, Reminder reminder)
        {
            await _reminderService.UpdateAsync(id, reminder);
            return Ok();
        }

        // POST: api/Reminders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reminder>> PostReminder(Reminder reminder)
        {
            await _reminderService.AddAsync(reminder);
            return Ok();
        }

        // DELETE: api/Reminders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            await _reminderService.RemoveAsync(id);
            return Ok();
        }
        [HttpDelete("Category/{id}")]
        public async Task DeleteAllByCategoryId(int id)
        {
         await _reminderService.DeleteAllByCategoryIdAsync(id);
        }
        
        [HttpGet("Category/{id}")]
        public async Task<IEnumerable<Reminder>> GetAllByCategoryId(int id)
        {
          return await _reminderService.GetAllBycategoryIdAsync(id);
        }

    }
}
