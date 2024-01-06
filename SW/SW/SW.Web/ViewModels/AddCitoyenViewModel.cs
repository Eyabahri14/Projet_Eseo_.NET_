using Microsoft.AspNetCore.Mvc.Rendering;
using SW.Models;

namespace SW.Web.ViewModels
{
    
    public class AddCitoyenViewModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public int EspeceId { get; set; }

        public List<SelectListItem> Especes { get; set; }
    }
}
