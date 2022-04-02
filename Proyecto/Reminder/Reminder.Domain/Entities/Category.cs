using Reminder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.Entities
{
    public class Category: EntityBase
    {
        public Category()
        {
            Reminders = new HashSet<Reminder>();
        }

        public string Description { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }


    }
}
