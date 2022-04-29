using System.ComponentModel.DataAnnotations;

namespace Reminder.Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}