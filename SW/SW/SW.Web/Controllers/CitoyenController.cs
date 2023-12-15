using Microsoft.AspNetCore.Mvc;
using SW.Models;
using SW.Services;
using System.Linq;

namespace SW.Web.Controllers
{
    public class CitoyenController : Controller
    {
        private readonly CitoyenService _citoyenService;

        public CitoyenController(CitoyenService citoyenService)
        {
            _citoyenService = citoyenService;
        }

        // GET: Citoyen
        public IActionResult Index()
        {
            var citoyens = _citoyenService.GetCitoyens();
            return View(citoyens);
        }


        // GET: Citoyen/Add
        [HttpGet]
        public IActionResult Add()
        {
            var citoyens = _citoyenService.GetCitoyens();

            var viewModel = new AddCitoyenViewModel
            {
                Peres = citoyens.ToList(),
                Meres = citoyens.ToList(),
                Citoyen = new Citoyen()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCitoyenViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Utilisez viewModel.Citoyen pour accéder aux données saisies
                _citoyenService.AddCitoyen(viewModel.Citoyen);
                return RedirectToAction(nameof(Index));
            }
            
            // Rechargez les listes de pères et de mères en cas d'échec de validation.
            var citoyens = _citoyenService.GetCitoyens();
            viewModel.Peres = citoyens.ToList();
            viewModel.Meres = citoyens.ToList();

            // Ajoutez des erreurs de modèle pour chaque erreur de validation
            ModelState.AddModelError("Citoyen.Peres", "Sélectionnez un père");
            ModelState.AddModelError("Citoyen.Meres", "Sélectionnez une mère");

            return View(viewModel);
            

        }


        // GET: Citoyen/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var citoyen = _citoyenService.GetCitoyenById(id);
            if (citoyen == null)
            {
                return NotFound();
            }
            return View(citoyen);
        }

        // POST: Citoyen/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Citoyen citoyen)
        {
            if (ModelState.IsValid)
            {
                _citoyenService.UpdateCitoyen(citoyen);
                return RedirectToAction(nameof(Index));
            }
            return View(citoyen);
        }

        // GET: Citoyen/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var citoyen = _citoyenService.GetCitoyenById(id);
            if (citoyen == null)
            {
                return NotFound();
            }
            return View(citoyen);
        }

        // POST: Citoyen/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _citoyenService.DeleteCitoyen(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
