using SW.Models;
using System.Collections.Generic;
using System.Linq;

namespace SW.DataAccessLayer
{
    public class CitoyenRepository
    {
        private readonly StarWarsDBContext _starWarsDBContext;

        public CitoyenRepository(StarWarsDBContext starWarsDBContext)
        {
            _starWarsDBContext = starWarsDBContext;
        }

        public void AddCitoyen(Citoyen citoyen)
        {
            _starWarsDBContext.Citoyens.Add(citoyen);
            _starWarsDBContext.SaveChanges();
        }

        public List<Citoyen> GetCitoyens()
        {
            return _starWarsDBContext.Citoyens.ToList();
        }

        public Citoyen GetCitoyenById(int id)
        {
            return _starWarsDBContext.Citoyens.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateCitoyen(Citoyen citoyen)
        {
            var existingCitoyen = _starWarsDBContext.Citoyens.FirstOrDefault(c => c.Id == citoyen.Id);
            if (existingCitoyen != null)
            {
                existingCitoyen.Nom = citoyen.Nom;
                existingCitoyen.Prenom = citoyen.Prenom;
                existingCitoyen.Age = citoyen.Age;
                existingCitoyen.Espece = citoyen.Espece;
                existingCitoyen.PereBiologiqueID = citoyen.PereBiologiqueID;
                existingCitoyen.PereBiologique = citoyen.PereBiologique;
                existingCitoyen.MereBiologiqueID = citoyen.MereBiologiqueID;
                existingCitoyen.MereBiologique = citoyen.MereBiologique;
                existingCitoyen.Bonheur = citoyen.Bonheur;
                existingCitoyen.Fertilite = citoyen.Fertilite;
                existingCitoyen.PointsDeMerites = citoyen.PointsDeMerites;

                _starWarsDBContext.SaveChanges();
            }
        }

        public void DeleteCitoyen(int id)
        {
            var citoyen = _starWarsDBContext.Citoyens.FirstOrDefault(c => c.Id == id);
            if (citoyen != null)
            {
                _starWarsDBContext.Citoyens.Remove(citoyen);
                _starWarsDBContext.SaveChanges();
            }
        }

      
    }
}
