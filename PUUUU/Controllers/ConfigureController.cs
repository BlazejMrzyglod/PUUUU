using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PUUUU.Data;
using PUUUU.Models.Models;
using PUUUU.Models.ViewModels;

namespace PUUUU.Controllers
{
    public class ConfigureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigureController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<BikePart> parts = _context.BikeParts.ToList();
            ConfigureViewModel viewModel = new ConfigureViewModel();
            viewModel.Frames = new SelectList(parts.Where(e => e.Type == "Frame"),"Id","Name",viewModel.FrameId);
            viewModel.Forks = new SelectList(parts.Where(e => e.Type == "Fork"), "Id", "Name",viewModel.ForkId);
            viewModel.Wheels = new SelectList(parts.Where(e => e.Type == "Wheels"), "Id", "Name", viewModel.WheelsId);
            viewModel.Saddles = new SelectList(parts.Where(e => e.Type == "Saddle"), "Id", "Name", viewModel.SaddleId);
            viewModel.Handles = new SelectList(parts.Where(e => e.Type == "Handle"), "Id", "Name", viewModel.HandleId);
            viewModel.Pedals = new SelectList(parts.Where(e => e.Type == "Pedals"), "Id", "Name", viewModel.PedalsId);
            return View(viewModel);
        }
    }
}
