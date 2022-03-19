using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Models
{
    public class ReportedCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string IssuingNetwork { get; set; }

        [Required]
        [StringLength(50)]
        public string CreditCardNumber { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string StatusCard { get; set; }

        [Required]
        public DateTime ReportedDate { get; set; }

        [Required]
        public DateTime LastUpdatedDate { get; set; }
    }
}
