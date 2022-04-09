using Reminder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Application.Interfaces.UseCases
{
    public interface IFindCategoryUseCase
    {
        IEnumerable<Category> Execute(Expression<Func<Category, bool>> predicate);
    }
}
