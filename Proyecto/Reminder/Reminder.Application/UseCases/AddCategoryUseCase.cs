using Reminder.Application.Interface.UseCases;
using Reminder.Domain.Entities;
using Reminder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Application.UseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        IRepository<Category> _categoryRepository;

        public AddCategoryUseCase(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public int Execute(Category category)
        {
            return _categoryRepository.Add(category);
        }
    }
}
