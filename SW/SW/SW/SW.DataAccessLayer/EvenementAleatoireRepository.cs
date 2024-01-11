using SW.Models;
using System;
using System.Linq;

namespace SW.DataAccessLayer
{
    public class EvenementAleatoireRepository
    {
        private readonly StarWarsDBContext _starWarsDBContext;
        private readonly Random _random = new Random();

        public EvenementAleatoireRepository(StarWarsDBContext starWarsDBContext)
        {
            _starWarsDBContext = starWarsDBContext;
        }

        // Méthode pour déclencher un événement aléatoire sur un citoyen spécifique
        public TypeEvenementAleatoire TriggerRandomEvenementAleatoire(Citoyen citoyen)
        {
            var selectedType = GetRandomEvenementType();
            ApplyEvenementImpact(selectedType, citoyen);

            _starWarsDBContext.SaveChanges();

            return selectedType;

        }

        // Sélectionne aléatoirement un type d'événement
        private TypeEvenementAleatoire GetRandomEvenementType()
        {
            var evenementTypes = Enum.GetValues(typeof(TypeEvenementAleatoire))
                                     .Cast<TypeEvenementAleatoire>()
                                     .ToList();

            return evenementTypes[_random.Next(evenementTypes.Count)];
        }

        // Applique l'impact de l'événement sur le citoyen
        // EvenementAleatoireService


        private void ApplyEvenementImpact(TypeEvenementAleatoire eventType, Citoyen citoyen)
        {
            bool shouldUpdateDivision = false;

            switch (eventType)
            {
                case TypeEvenementAleatoire.CatastropheNaturelle:
                    citoyen.Bonheur -= 10;
                    citoyen.PointsDeMerites -= 15;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.FeteNationale:
                    citoyen.Bonheur += 5;
                    citoyen.PointsDeMerites += 10;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.RecolteAbondante:
                    citoyen.Fertilite += 2;
                    citoyen.Bonheur += 2;
                    citoyen.PointsDeMerites += 5;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.Epidemie:
                    citoyen.Bonheur -= 5;
                    citoyen.PointsDeMerites -= 10;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.MortParentBiologique:
                    citoyen.Bonheur -= 20;
                    citoyen.PointsDeMerites -= 20;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.PrixScientifique:
                    citoyen.PointsDeMerites += 20;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.ExploitSportif:
                    citoyen.PointsDeMerites += 15;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.ProjetCommunautaireReussi:
                    citoyen.PointsDeMerites += 10;
                    shouldUpdateDivision = true;
                    break;
                case TypeEvenementAleatoire.IncidentDiplomatique:
                    citoyen.PointsDeMerites -= 25;
                    shouldUpdateDivision = true;
                    break;
                    // Ajoutez d'autres types d'événements si nécessaire
            }

            // Mise à jour de la division du citoyen si nécessaire
            if (shouldUpdateDivision)
            {
                citoyen.MiseAJourDivision();
            }

            // Mettez à jour les propriétés du citoyen dans la base de données
            _starWarsDBContext.Update(citoyen);
            _starWarsDBContext.SaveChanges();
        }

    }
}
