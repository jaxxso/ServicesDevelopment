using Reminder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Application.Interface.UseCases
{
    public interface IAddCategoryUseCase
    {
        int Execute(Category category);
    }
}
