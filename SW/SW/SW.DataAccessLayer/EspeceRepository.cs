using SW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DataAccessLayer
{
    public class EspeceRepository
    {
        public StarWarsDBContext StarWarsDBContext { get; set; }

        public EspeceRepository(StarWarsDBContext starWarsDBContext)
        {
            StarWarsDBContext = starWarsDBContext;
        }

        public void AddEspece(Espece e)
        {
            StarWarsDBContext.Especes.Add(e);
            StarWarsDBContext.SaveChanges();
        }
    }
}
