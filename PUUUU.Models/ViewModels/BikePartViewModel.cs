using Microsoft.AspNetCore.Mvc.Rendering;
using PUUUU.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PUUUU.Models.ViewModels
{
    public class BikePartViewModel
    {
        [Required]
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Typ")]
        public SelectList Type { get; set; }
        [Required]
        [Display(Name = "Cena")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }
        public virtual ICollection<ConfigureOrder>? Orders { get; set; }
    }
}
