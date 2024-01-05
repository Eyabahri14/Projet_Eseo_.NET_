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
            citoyen.Fertilite = 0;
            citoyen.Bonheur = 0;   
            citoyen.PointsDeMerites = 0; 
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

        public double GetBonheurMoyen()
        {
            var citoyens = _citoyenRepository.GetCitoyens();
            if (citoyens.Any())
            {
                var bonheurMoyen = citoyens.Average(c => c.Bonheur ?? 0);
                return bonheurMoyen;
            }
            return 0;
        }

    }
}
