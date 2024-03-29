﻿using Microsoft.AspNetCore.Mvc;
using PUUUU.Data;
using PUUUU.Models;
using PUUUU.Models.ViewModels;
using System.Diagnostics;

namespace PUUUU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Configure()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        
        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Shipment()
        {
            return View();
        }
        public IActionResult Returns()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}