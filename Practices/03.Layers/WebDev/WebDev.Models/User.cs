using System;
using System.ComponentModel.DataAnnotations;

namespace WebDev.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email es requerida")]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password es requerido")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Username es requerido")]
        public string Username { get; set; }
    }
}
