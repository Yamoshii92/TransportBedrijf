using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TransportBedrijfMVC.Models;
using TransportBedrijfMVC.Repositories;

namespace TransportBedrijfMVC.Controllers
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
            var repo = new VoertuigRepository();
            var voertuigen = repo.GetAll();
            return View(voertuigen);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Voertuig voertuig)
        {
            var repo = new VoertuigRepository();
            repo.Add(voertuig);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
