using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Domain
{
   public class Reminder
   {
      public int Ind { get; set; }
      public int CategoryId { get; set; }
      public string Description { get; set; }
      public DateTime StartDate { get; set; }
      public string CronExpression { get; set; }
      public int? NumberOfTimes { get; set; }
      public bool? Enabled { get; set; }

      public virtual Category Category { get; set; }
   }
}
