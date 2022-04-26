using ReminderApp.Application.Interfaces.Usecases;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Interfaces.Repository;
using ReminderApp.Infrastructure.Repositories;
using System.Collections.Generic;

namespace ReminderApp.Application.UseCases
{
   public class GetAllCategoryUseCase : IGetAllCategoryUseCase
   {
      private readonly CategoryRepository _categoryRepository;

      public GetAllCategoryUseCase(CategoryRepository categoryRepository)
      {
         _categoryRepository = categoryRepository;
      }

      public IEnumerable<Category> Execute()
      {
         return _categoryRepository.GetAll();
      }
   }
}