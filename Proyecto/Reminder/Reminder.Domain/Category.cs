using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain
{
    public class Category
    {
        public Category()
        {
            Reminders = new HashSet<Reminder>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }


    }
}
