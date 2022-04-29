using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.Entities
{
    public class Category : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string description { get; set; }
    }

}
}
