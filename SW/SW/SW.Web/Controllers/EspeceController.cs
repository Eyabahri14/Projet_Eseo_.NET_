using Microsoft.AspNetCore.Mvc;
using SW.Services;
using SW.Web.ViewModels;

namespace SW.Web.Controllers
{
    public class EspeceController : Controller
    {
        public EspeceService EspeceService { get; set; }

        public EspeceController(EspeceService especeService)
        {
            EspeceService = especeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEspeceViewModel addEspeceViewModel)
        {
            EspeceService.AddEspece(new SW.Models.Espece
            {
                Nom = addEspeceViewModel.Nom,
                Longevite = addEspeceViewModel.Longevite,
                Majorite = addEspeceViewModel.Majorite
            });
            return View();
        }
    }
}
