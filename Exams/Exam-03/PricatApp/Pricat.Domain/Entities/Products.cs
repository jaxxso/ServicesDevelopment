using Pricat.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricat.Domain.Entities
{
   public class Products : EntityBase
    {

      [Required]
      public int CategoryId { get; set; }

      [Required]
      [MaxLength(13)]
      [DataType(DataType.Text)]
      public string EanCode { get; set; }

      [Required]
      [MaxLength(50)]
      [DataType(DataType.Text)]
      public string Description { get; set; }

      [Required]
      [MaxLength(15)]
      [DataType(DataType.Text)]
      public string Unit { get; set; }

      [Required]
      [Range(0, float.MaxValue)]
      public double Price { get; set; }

   }
}
