using Pricat.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pricat.Domain.Entities
{
   public class Categories : EntityBase
    {
      public Categories()
      {
      }

      [Required]
      [MaxLength(50)]
      [DataType(DataType.Text)]
      public string Description { get; set; }

   }
}