using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Domain.Entities
{
    public class Reminder : EntityBase
    { 
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string CronExpression { get; set; }
        public int NumberOfTimes { get; set; }
        public bool Enabled { get; set; }

    }
}
