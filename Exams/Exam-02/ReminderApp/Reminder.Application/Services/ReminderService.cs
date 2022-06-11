﻿using Reminder.Application.Interfaces;
using Reminder.Domain.Entities;
using Reminder.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Application.Services
{
    public class ReminderService: IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task AddAsync(Domain.Entities.Reminder entity)
        {
            await _reminderRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Domain.Entities.Reminder>> FindAsync(Expression<Func<Domain.Entities.Reminder, bool>> predicate)
        {
            return await _reminderRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<Domain.Entities.Reminder>> GetAllAsync()
        {
            return await _reminderRepository.GetAllAsync();
        }

        public async Task GetByIdAsync(int id)
        {
            await _reminderRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Domain.Entities.Reminder entity)
        {
            await _reminderRepository.UpdateAsync(entity);
        }
    }
}