using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.ViewModels
{
    public class ConfigureViewModel
    {
        public SelectList Frames { get; set; }
        public SelectList Forks { get; set; }
        public SelectList Wheels { get; set; }
        public SelectList Saddles { get; set; }
        public SelectList Handles { get; set; }
        public SelectList Pedals { get; set; }
    }
}
