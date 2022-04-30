using System;
using System.ComponentModel.DataAnnotations;

namespace ReminderApi.Api.Models
{
    public class ReminderEntry
    {
        [Required]
        public int Id { get; set; }

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
    }
}
