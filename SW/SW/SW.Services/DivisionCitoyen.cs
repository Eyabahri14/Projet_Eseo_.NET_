using SW.DataAccessLayer;
using SW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services
{
    public class DivisionCitoyen
    {
        private readonly CitoyenRepository _citoyenRepository;
        public DivisionCitoyen(CitoyenRepository repository)
        {
            _citoyenRepository = repository;
        }

        public void AddCitoyen(Citoyen c)
        {
            _citoyenRepository.AddCitoyen(c);
        }

        public List<Citoyen> GetCitoyens()
        {
            return _citoyenRepository.GetCitoyens();
        }

        public Citoyen GetCitoyenById(int id)
        {
            return _citoyenRepository.GetCitoyenById(id);
        }

        public void UpdateEspece(Citoyen citoyen)
        {
            _citoyenRepository.UpdateCitoyen(citoyen);
        }

        public void DeleteCitoyen(int id)
        {
            _citoyenRepository.DeleteCitoyen(id);
        }
    }
}
