using System;
using System.ComponentModel.DataAnnotations;

namespace NetBank.Models
{
    public class ReportedCard
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "IssuingNetwork es requerida")]
        public string IssuingNetwork { get; set; }

        [Required(ErrorMessage = "CreditCardNumber es requerida")]
        public string CreditCardNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "StatusCard es requerido")]
        public string StatusCard { get; set; }


        [Required(ErrorMessage = "ReportedDate es requerido")]
        public System.DateTime ReportedDate { get; set; }

        [Required(ErrorMessage = "LastUpdatedDate es requerido")]
        public System.DateTime LastUpdatedDate { get; set; }
    }
}
