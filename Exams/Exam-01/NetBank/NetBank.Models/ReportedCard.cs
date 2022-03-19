using System;
using System.ComponentModel.DataAnnotations;

namespace NetBank.Models
{
    public class ReportedCard
    {

            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "El IssuingNetwork es obligatorio")]
            public string IssuingNetwork { get; set; }
            [Required(ErrorMessage = "El CreditCardNumber es obligatorio")]
            public string CreditCardNumber { get; set; }
            public string FirstName { get; set; }
 
            public string LastName { get; set; }
            [Required(ErrorMessage = "El StatusCard es obligatorio")]
            public string StatusCard { get; set; }
            [Required(ErrorMessage = "El ReportedDate es obligatorio")]
            public DateTime ReportedDate { get; set; }
            [Required(ErrorMessage = "El LastUpdatedDate es obligatorio")]
            public DateTime LastUpdatedDate { get; set; }
     }
    
}

