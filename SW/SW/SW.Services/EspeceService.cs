using SW.DataAccessLayer;
using SW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services
{
    public class EspeceService
    {
        public EspeceRepository EspeceRepository { get; set; }

        public EspeceService(EspeceRepository especeRepository)
        {
            EspeceRepository = especeRepository;
        }

        public void AddEspece(Espece espece)
        {
            EspeceRepository.AddEspece(espece);
        }
    }
}
