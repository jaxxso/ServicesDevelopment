using ReminderApi.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReminderApi.Api.Models
{
    public class CategoryEntry
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }


    }
}
