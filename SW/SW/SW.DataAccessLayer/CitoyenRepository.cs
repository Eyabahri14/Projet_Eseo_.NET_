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

        public List<Citoyen> GetAllCitoyens()
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

        public void DeleteCitoyen(int id)
        {
            var espece = _starWarsDBContext.Especes.FirstOrDefault(e => e.Id == id);
            if (espece != null)
            {
                _starWarsDBContext.Especes.Remove(espece);
                _starWarsDBContext.SaveChanges();
            }
        }

        public void GenerateArbreGenealogique(Citoyen citoyen)
        {
            Console.WriteLine($"Arbre généalogique pour le citoyen {citoyen.Nom} {citoyen.Prenom}:");
            GenerateArbre(citoyen, 0);
        }

        private void GenerateArbre(Citoyen citoyen, int level)
        {
            // Affiche le nom et prénom du citoyen avec un décalage en fonction du niveau dans l'arbre
            Console.WriteLine($"{new string(' ', level * 4)}- {citoyen.Nom} {citoyen.Prenom}");

            // Récupère les parents biologiques du citoyen
            var pere = citoyen.PereBiologique;
            var mere = citoyen.MereBiologique;

            // Appelle récursivement la méthode pour chaque parent biologique
            if (pere != null)
            {
                Console.WriteLine($"{new string(' ', (level + 1) * 4)}Père:");
                GenerateArbre(pere, level + 2);
            }

            if (mere != null)
            {
                Console.WriteLine($"{new string(' ', (level + 1) * 4)}Mère:");
                GenerateArbre(mere, level + 2);
            }
        }

    }
}

