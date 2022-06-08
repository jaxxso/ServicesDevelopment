using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reminder.Domain.Entities;
using Reminder.Infrastructure.Context;

namespace Reminder.Api.Controllers
{
    [Route("api/v1/Reminder")]
    [ApiController]
    public class RemindersAppController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RemindersAppController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReminderApps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Reminder>>> GetReminder()
        {
            return await _context.Reminders.ToListAsync();
        }

        // GET: api/ReminderApps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Entities.Reminder>> GetReminderApp(int id)
        {
            var reminderApp = await _context.Reminders.FindAsync(id);

            if (reminderApp == null)
            {
                return NotFound();
            }

            return reminderApp;
        }

        // PUT: api/ReminderApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminderApp(int id, Domain.Entities.Reminder reminderApp)
        {
            if (id != reminderApp.Id)
            {
                return BadRequest();
            }

            _context.Entry(reminderApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReminderAppExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReminderApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Domain.Entities.Reminder>> PostReminderApp(Domain.Entities.Reminder reminderApp)
        {
            _context.Reminders.Add(reminderApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReminderApp", new { id = reminderApp.Id }, reminderApp);
        }

        // DELETE: api/ReminderApps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminderApp(int id)
        {
            var reminderApp = await _context.Reminders.FindAsync(id);
            if (reminderApp == null)
            {
                return NotFound();
            }

            _context.Reminders.Remove(reminderApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReminderAppExists(int id)
        {
            return _context.Reminders.Any(e => e.Id == id);
        }

        //GetAllById
        // GET api/v1/<RemindersController>/category/5
        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(await _context.GetAllByCategoryIdAsync(id));
        }

        //DeleteAllById
        // DELETE api/v1/<RemindersController>/category/5
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteAllByCategoryId(int id)
        {
            await _context.RemoveAllByCategoryIdAsync(id);
            return Ok();
        }

        // DELETE api/v1/<RemindersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _context.RemoveAsync(id);
            return Ok();
        }

    }
}
