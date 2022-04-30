using ReminderApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Domain.Entities
{
    public partial class Category : EntityBase
    {
        public Category()
        {
            this.Reminders = new HashSet<Reminder>();
        }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }

        
    }
}
