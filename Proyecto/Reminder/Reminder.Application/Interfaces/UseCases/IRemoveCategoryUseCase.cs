using Reminder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Application.Interfaces.UseCases
{
    public interface IRemoveCategoryUseCase
    {
        void Execute(Category category);
    }
}
