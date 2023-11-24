using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SW.Models;
using SW.Services;

namespace SW.Web.Controllers
{
    public class CitoyenController : Controller
    {
        private readonly DivisionCitoyen _citoyenService; 
        // GET: CitoyenController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CitoyenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CitoyenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CitoyenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Citoyen/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Citoyen/Add
        [HttpPost]
        public IActionResult Add(Citoyen citoyen)
        {
            if (ModelState.IsValid)
            {
                _citoyenService.AddCitoyen(citoyen);
                return RedirectToAction(nameof(Index));
            }
            return View(citoyen);
        }

        // GET: CitoyenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CitoyenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CitoyenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CitoyenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
