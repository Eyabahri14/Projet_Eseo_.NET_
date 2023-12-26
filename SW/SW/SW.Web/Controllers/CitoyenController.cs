﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
