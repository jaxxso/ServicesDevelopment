﻿using ReminderApp.Domain.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace ReminderApp.Domain.Entities
{
    public partial class Reminder : EntityBase
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string CronExpression { get; set; }
        public int? NumberOfTimes { get; set; }
        public bool? Enabled { get; set; }

        public virtual Category Category { get; set; }
    }
}
