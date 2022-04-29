using ReminderApp.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReminderApp.Domain.Entities
{
   public class Category : EntityBase
    {
      public Category()
      {
      }
      public string Description { get; set; }

   }
}