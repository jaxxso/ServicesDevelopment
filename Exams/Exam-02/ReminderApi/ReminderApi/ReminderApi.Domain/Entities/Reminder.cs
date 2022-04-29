using ReminderApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApi.Domain.Entities
{
    public partial class Reminder : EntityBase
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string CronExpression { get; set; }

        public int? NumberOfTimes { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public virtual Category Category { get; set; }

    }
}
