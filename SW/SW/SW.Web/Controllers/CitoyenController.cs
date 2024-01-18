using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SW.Models;
using SW.Services;
using SW.Web.ViewModels;
using System.Linq;

namespace SW.Web.Controllers
{
    public class CitoyenController : Controller
    {
        private readonly CitoyenService _citoyenService;
        private readonly EvenementAleatoireService _evenementAleatoireService;


        public CitoyenController(CitoyenService citoyenService, EvenementAleatoireService evenementAleatoire)
        {
            _citoyenService = citoyenService;
            _evenementAleatoireService = evenementAleatoire;
        }

        // GET: Citoyen
        public IActionResult Index()
        {
            var citoyens = _citoyenService.GetCitoyens();
            var bonheurMoyen = _citoyenService.GetBonheurMoyen();

            ViewBag.BonheurMoyen = bonheurMoyen; 

            return View(citoyens);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var citoyens = _citoyenService.GetCitoyens();

            var viewModel = new Citoyen
            {
                Citoyens = citoyens.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(Citoyen citoyen)
        {
            // Chargez à nouveau la liste des citoyens
              citoyen.Citoyens = _citoyenService.GetCitoyens().ToList();

           // if (ModelState.IsValid)
            //{
                // Recherchez le citoyen sélectionné par ID dans la liste des pères
                citoyen.PereBiologique = citoyen.Citoyens.FirstOrDefault(c => c.Id == citoyen.PereBiologiqueID);

                // Faites de même pour la mère si nécessaire
                citoyen.MereBiologique = citoyen.Citoyens.FirstOrDefault(c => c.Id == citoyen.MereBiologiqueID);

                _citoyenService.AddCitoyen(citoyen);
                return RedirectToAction(nameof(Index));
            // }

            // Si le modèle n'est pas valide, retournez la vue avec le modèle et les erreurs
            // return View(citoyen);
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

        [HttpPost]
        public IActionResult ApplyRandomEvenement(int id)
        {
            var evenementType = _evenementAleatoireService.ApplyRandomEvenementToCitoyen(id);

            var message = $"L'événement aléatoire {evenementType} a été appliqué avec succès sur le citoyen.";

            return Content(message);
        }


        // GET: CitoyenController/GenerateArbreGenalogique
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateArbreGenealogique(int id)
        {
            try
            {
                var citoyen = _citoyenService.GetCitoyenById(id);

                if (citoyen == null)
                {
                    // Gérer le cas où le citoyen n'est pas trouvé (par exemple, rediriger vers une page d'erreur)
                    return RedirectToAction(nameof(Index));
                }

                _citoyenService.GenerateArbreGenealogique(citoyen);

                // Si l'arbre généalogique est généré avec succès, vous pouvez rediriger vers une autre action ou vue
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Gérer les exceptions ici (par exemple, journalisation, affichage d'un message d'erreur, etc.)
                return View();
            }
        }


    }
}
