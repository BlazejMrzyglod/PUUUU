using Microsoft.AspNetCore.Mvc.Rendering;
using PUUUU.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUUUU.Models.ViewModels
{
    public class ConfigureViewModel
    {
        public int FrameId { get; set; }
        public SelectList Frames { get; set; }
        public int ForkId { get; set; }
        public SelectList Forks { get; set; }
        public int WheelsId { get; set; }
        public SelectList Wheels { get; set; }
        public int SaddleId { get; set; }
        public SelectList Saddles { get; set; }
        public int HandleId { get; set; }
        public SelectList Handles { get; set; }
        public int PedalsId { get; set; }
        public SelectList Pedals { get; set; }
    }
}
