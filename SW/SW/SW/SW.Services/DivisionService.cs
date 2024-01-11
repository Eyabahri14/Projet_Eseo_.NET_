using SW.DataAccessLayer;
using SW.Models;
using System.Collections.Generic;

namespace SW.Services
{
    public class DivisionService
    {

        private readonly CitoyenRepository _citoyenRepository;
        private object array;

        public DivisionService(CitoyenRepository citoyenRepository)
        {
            _citoyenRepository = citoyenRepository;
        }

        public static Enum GetDivisions()
        {
            return new Division();
        }
        public double[] GetProductionEconomiqueTotaleParDivision()
        {
            var divisions = Enum.GetValues(typeof(Division))
                     .Cast<Division>()
                     .ToList();
            double[] array = new double[divisions.Count];
            foreach (var division in divisions)
            {

                var citoyens = _citoyenRepository.GetCitoyensByDivision(division);
                if (citoyens.Any())
                {
                    //todo: 
                    //var productionEconomiqueTotale = citoyens.Sum(c => c.ProductionEconomique ?? 0);
                    //array[(int)division] = productionEconomiqueTotale;
                    array[(int)division] = -99999;
                }
                else
                {
                    array[(int)division] = -99999;
                }
            }
            return array;
        }
        public double[] GetBonheurMoyenParDivision()
        {
            var divisions = Enum.GetValues(typeof(Division))
                                .Cast<Division>()
                                .ToList();
            double[]? array = new double[divisions.Count];
            foreach (var division in divisions)
            {

                var citoyens = _citoyenRepository.GetCitoyensByDivision(division);
                if (citoyens.Any())
                {
                    var bonheurMoyen = citoyens.Average(c => c.Bonheur ?? 0);
                    array[(int)division] = bonheurMoyen;
                } else
                {
                    array[(int)division] = -99999;
                }
            }
            return array;
        }
    }
}
