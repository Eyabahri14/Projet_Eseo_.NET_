using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SW.Models
{
    public class CitoyenViewModel
    {
        public Citoyen Citoyen { get; set; }
        public List<Citoyen> Peres { get; set; }
        public List<Citoyen> Meres { get; set; }
    }
}
