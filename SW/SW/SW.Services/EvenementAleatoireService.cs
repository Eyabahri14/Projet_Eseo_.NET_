using SW.DataAccessLayer;
using SW.Models;

namespace SW.Services
{
    public class EvenementAleatoireService
    {
        private readonly EvenementAleatoireRepository _evenementAleatoireRepository;
        private readonly CitoyenRepository _citoyenRepository;

        public EvenementAleatoireService(EvenementAleatoireRepository evenementAleatoireRepository, CitoyenRepository citoyenRepository)
        {
            _evenementAleatoireRepository = evenementAleatoireRepository;
            _citoyenRepository = citoyenRepository;
        }

        // Déclenche un événement aléatoire sur un citoyen spécifique
        public TypeEvenementAleatoire ApplyRandomEvenementToCitoyen(int citoyenId)
        {
            var citoyen = _citoyenRepository.GetCitoyenById(citoyenId);
            if (citoyen != null)
            {
                return _evenementAleatoireRepository.TriggerRandomEvenementAleatoire(citoyen);
            }
            return TypeEvenementAleatoire.CatastropheNaturelle;

        }

        // Optionnellement, déclenche un événement aléatoire sur tous les citoyens
        public void ApplyRandomEvenementToAllCitoyens()
        {
            var allCitoyens = _citoyenRepository.GetCitoyens();
            foreach (var citoyen in allCitoyens)
            {
                _evenementAleatoireRepository.TriggerRandomEvenementAleatoire(citoyen);
            }
        }
    }
}
