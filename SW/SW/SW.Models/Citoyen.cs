using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SW.Models
{
    

    public class Citoyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public Espece? Espece { get; set; }
        public int? PereBiologiqueID { get; set; }
        public Citoyen? PereBiologique { get; set; }
        public int? MereBiologiqueID { get; set; }
        public Citoyen? MereBiologique { get; set; }
        public int? Bonheur { get; set; }
        public int? Fertilite { get; set; }
        public int? PointsDeMerites { get; set; }

        public Division Division { get; set; } 

        public List<Citoyen> Citoyens { get; set; }

        public Citoyen()
        {
            Division = Division.Nouveau; 
        }

        public void MiseAJourDivision()
        {
            if (PointsDeMerites >= 200)
            {
                Division = Division.Patriote;
            }
            else if (PointsDeMerites >= 150)
            {
                Division = Division.Professionnel;
            }
            else if (PointsDeMerites >= 100)
            {
                Division = Division.Fonctionnaire;
            }
            else if (PointsDeMerites >= 50)
            {
                Division = Division.Travailleur;
            }
            else
            {
                Division = Division.Nouveau;
            }
        }

    }
}
