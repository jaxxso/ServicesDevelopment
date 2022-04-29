using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Domain
{
    public class Category
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }
    }

}

      
