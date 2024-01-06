using Microsoft.AspNetCore.Mvc;
using SW.Models;
using SW.Services;
using SW.Web.Models;
using System.Diagnostics;

namespace SW.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly EvenementAleatoireService _evenementAleatoireService;

        public HomeController(ILogger<HomeController> logger, EvenementAleatoireService evenementAleatoireService)
        {
            _logger = logger;
            _evenementAleatoireService = evenementAleatoireService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult TourSuivant()
        {
            
            _evenementAleatoireService.ApplyRandomEvenementToAllCitoyens();
            return RedirectToAction(nameof(Index));
        }

        public string Test(string param)
        {
            return $"Bonjour {param} !";
        }

        public IActionResult Privacy()
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