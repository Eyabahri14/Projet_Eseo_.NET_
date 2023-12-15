using SW.DataAccessLayer;
using SW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services
{
    public class CitoyenService
    {

        private readonly CitoyenRepository _citoyenRepository;

        public CitoyenService(CitoyenRepository citoyenRepository)
        {
            _citoyenRepository = citoyenRepository;
        }

        public void AddCitoyen(Citoyen citoyen)
        {
            _citoyenRepository.AddCitoyen(citoyen);
        }

        public List<Citoyen> GetAllCitoyens()
        {
            return _citoyenRepository.GetAllCitoyens();
        }

        public Citoyen GetEspeceById(int id)
        {
            return _citoyenRepository.GetCitoyenById(id);
        }

        public void UpdateCitoyen(Citoyen citoyen)
        {
            _citoyenRepository.UpdateCitoyen(citoyen);
        }

        public void DeleteCitoyen(int id)
        {
            _citoyenRepository.DeleteCitoyen(id);
        }
    }
}
