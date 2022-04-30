using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
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
            await _reminderRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Reminder>> FindAsync(Expression<Func<Reminder, bool>> predicate)
        {
            return await _reminderRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Reminder>> GetAllAsync()
        {
            return await _reminderRepository.GetAllAsync();
        }

        public async Task<Reminder> GetByIdAsync(int id)
        {
            var reminder = await _reminderRepository.GetByIdAsync(id);

            // Validte If Exist
            return reminder;
        }

        public async Task RemoveAsync(int id)
        {
            var reminder = await _reminderRepository.GetByIdAsync(id);
            await _reminderRepository.RemoveAsync(reminder);
        }

        public async Task UpdateAsync(int id, Reminder entity)
        {
            // Validate if Exist
            await _reminderRepository.UpdateAsync(entity);
        }
         public async Task DeleteAllByCategoryIdAsync(int id)
        {
            await _reminderRepository.DeleteAllByCategoryId(id);

        }
        public async Task<IEnumerable<Reminder>> GetAllBycategoryIdAsync(int id)
        {
            return await _reminderRepository.GetAllBycategoryId(id);
             
        }
    }
}
