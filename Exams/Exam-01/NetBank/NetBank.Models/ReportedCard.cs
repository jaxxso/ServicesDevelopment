﻿namespace NetBank.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ReportedCard
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "IssuingNetwork is required")]
        public string IssuingNetwork { get; set; }

        [Required(ErrorMessage = "CreditCardNumber is required")]
        public string CreditCardNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "StatusCard is required")]
        public string StatusCard { get; set; }

        [Required(ErrorMessage = "ReportedDate is required")]
        public System.DateTime ReportedDate { get; set; }

        [Required(ErrorMessage = "LastUpdatedDate is required")]
        public System.DateTime LastUpdatedDate { get; set; }
    }
}