using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SW.Models
{
    public class Citoyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrémentation
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

        // Nouvelle propriété pour stocker la liste des citoyens
        public List<Citoyen> Citoyens { get; set; }
    }
}
