using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.ViewModels
{
    public class Contact
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string? Email { get; set; }
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string? Name { get; set; }
        [Display(Name = "Wiadomość")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string? Message { get; set; }
    }
}
