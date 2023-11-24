using SQLitePCL;
using System.Collections.Generic;
using SW.Models;

namespace SW.DataAccessLayer
{
    public class CitoyenRepository
    {
        private readonly StarWarsDBContext _starWarsDBContext;
        public CitoyenRepository(
            StarWarsDBContext starWarsDBContext // Le StarWarsDBContext est injecté grâce au program.cs
        )
        {
            _starWarsDBContext = starWarsDBContext;
        }

        public void AddCitoyen(Citoyen citoyen)
        {
            // Ajout du citoyen dans le contexte des citoyens
            _starWarsDBContext.Citoyens.Add(citoyen);

            // Sauvegarde des changements en base
            _starWarsDBContext.SaveChanges();
        }

        public List<Citoyen> GetCitoyens()
        {
            return _starWarsDBContext.Citoyens.ToList();
        }
        public Citoyen GetCitoyenById(int id)
        {
            return _starWarsDBContext.Citoyens.FirstOrDefault(e => e.Id == id);

        }

        public void UpdateCitoyen(Citoyen citoyen)
        {
            var existingCitoyen = _starWarsDBContext.Especes.FirstOrDefault(e => e.Id == citoyen.Id);
            if (existingCitoyen != null)
            {
                existingCitoyen.Nom = citoyen.Nom;
                _starWarsDBContext.SaveChanges();
            }
        }

        public void DeleteEspece(int id)
        {
            var espece = _starWarsDBContext.Especes.FirstOrDefault(e => e.Id == id);
            if (espece != null)
            {
                _starWarsDBContext.Especes.Remove(espece);
                _starWarsDBContext.SaveChanges();
            }
        }
    }
}

