using ReminderApi.Application.Interfaces;
using ReminderApi.Domain.Entities;
using ReminderApi.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Application.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task AddAsync(Reminder entity)
        {
            if (entity.StartDate >= DateTime.Now) await _reminderRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Reminder>> FindAsync(Expression<Func<Reminder, bool>> predicate)
        {
            return await _reminderRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Reminder>> GetAllAsync()
        {
            return await _reminderRepository.GetAllAsync();
        }

        public async Task<Reminder> GetByAsyncId(int id)
        {
            var reminder = await _reminderRepository.GetByAsyncId(id);
            if (reminder == null) return null;
            return reminder;
        }

        public async Task RemoveAsync(int id)
        {
            var reminder = await _reminderRepository.GetByAsyncId(id);
            if (reminder != null) await _reminderRepository.RemoveAsync(reminder);
        }

        public async Task UpdateAsync(int id, Reminder entity)
        {
            if (entity.StartDate >= DateTime.Now) await _reminderRepository.UpdateAsync(entity); 
        }

        public async Task<IEnumerable<Reminder>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _reminderRepository.GetAllByCategoryIdAsync(categoryId);
        }

        public async Task RemoveAllByCategoryIdAsync(int categoryId)
        {
            await _reminderRepository.RemoveAllByCategoryIdAsync(categoryId);
        }
    }
}
