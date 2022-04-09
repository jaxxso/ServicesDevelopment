using ReminderApp.Application.Interfaces.Usecases;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Interfaces.Repository;

namespace ReminderApp.Application.UseCases
{
   public class AddCategoryUseCase : IAddCategoryUseCase
   {
      private readonly IRepository<Category> _categoryRepository;

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