using ReminderApp.Application.Interfaces.Usecases;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.UseCases
{
    internal class AddCategoryUseCases : IAddCategoryUseCase
    {
        private readonly IRepository<Category> _categoryRepository;

        public AddCategoryUseCases(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public int Execute(Category category)
        {
            return _categoryRepository.Add(category);
        }
    }
}
