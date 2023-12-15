using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Models
{
    public class AddCitoyenViewModel
    {
        public Citoyen Citoyen { get; set; }
        public List<Citoyen> Peres { get; set; }
        public List<Citoyen> Meres { get; set; }
    }
}
