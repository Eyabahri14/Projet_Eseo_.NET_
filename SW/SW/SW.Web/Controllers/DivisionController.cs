using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SW.DataAccessLayer.Migrations;
using SW.Models;
using SW.Services;
using SW.Web.ViewModels;
using System.Linq;

namespace SW.Web.Controllers
{
    public class DivisionController : Controller
    {
        private readonly DivisionService _divisionService;
       

        public DivisionController(DivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        public DivisionService Get_divisionService()
        {
            return _divisionService;
        }

        // GET: Division
        public IActionResult Index()
        {
            var bonheurMoyenParDivision = _divisionService.GetBonheurMoyenParDivision();
            var productionEconomiqueTotaleParDivision = _divisionService.GetProductionEconomiqueTotaleParDivision();

            ViewBag.BonheurMoyenParDivision = bonheurMoyenParDivision;
            ViewBag.ProductionEconomiqueTotaleParDivision =productionEconomiqueTotaleParDivision;
            return View();
        }
    }
}
