using Microsoft.AspNetCore.Mvc;
using SW.DataAccessLayer;
using SW.Models;
using SW.Services;
using SW.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SW.Web.Controllers
{
    public class NouveauController : Controller
    {
        public DivisionNouveau DivisionNouveau { get; set; }

        public DivisionCitoyen DivisionCitoyen { get; set; }

        public NouveauController(DivisionCitoyen divisionCitoyen)
        {
            DivisionNouveau = new DivisionNouveau();

            DivisionCitoyen = divisionCitoyen;
        }



    }
}
