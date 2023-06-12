using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PUUUU.Data;
using PUUUU.Models.Models;
using PUUUU.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace PUUUU.Controllers
{
    public class ConfigureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ConfigureController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        [HttpPost]
        public IActionResult Index([Bind("FrameId,ForkId,WheelsId,SaddleId,HandleId,PedalsId")] ConfigureViewModel configuration)
        {
            ConfigureOrder order = new ConfigureOrder();
            order.Address = " ";
            order.DeliveryMethod = " ";
            order.PaymentMethod = " ";
            order.CreatedDate = DateTime.Now;
            order.User = _userManager.FindByNameAsync("test@test.com").Result;
            order.Parts = new List<BikePart>();
            order.Parts.Add(_context.BikeParts.Find(configuration.FrameId));
            order.Parts.Add(_context.BikeParts.Find(configuration.ForkId));
            order.Parts.Add(_context.BikeParts.Find(configuration.WheelsId));
            order.Parts.Add(_context.BikeParts.Find(configuration.SaddleId));
            order.Parts.Add(_context.BikeParts.Find(configuration.HandleId));
            order.Parts.Add(_context.BikeParts.Find(configuration.PedalsId));
            _context.ConfigureOrders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
