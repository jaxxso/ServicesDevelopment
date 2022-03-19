using System.ComponentModel.DataAnnotations;

namespace NetBank.Models
{
    public class ReportedCard
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la red emisora es obligatorio")]
        public string IssuingNetwork { get; set; }

        [Required(ErrorMessage = "El numero de tarjeta es obligatorio")]
        public string CreditCardNumber { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required(ErrorMessage = "El estado de la tarjeta es obligatorio")]
        public string StatusCard { get; set; }

        [Required(ErrorMessage = "La fecha de reporte de la tarjeta es obligatorio")]
        public string ReportedDate { get; set; }

        [Required(ErrorMessage = "La fecha de actualizacion de la tarjeta es obligatorio")]
        public string LastUpdatedDate { get; set; }
    }
}