using SW.DataAccessLayer;
using SW.Models;
using System.Collections.Generic;

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

        public List<Citoyen> GetCitoyens()
        {
            return _citoyenRepository.GetCitoyens();
        }

        public Citoyen GetCitoyenById(int id)
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
