namespace SW.Models
{
    
    public class Citoyen

    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public Espece Espece { get; set; }


        public int PereBiologiqueID { get; set; }

        public Citoyen? PereBiologique { get; set; }
        public int MereBiologiqueID { get; set; }
        public Citoyen? MereBiologique { get; set; }
        public int? Bonheur { get; set; }
        public int? Fertilite { get; set; }
        public int? PointsDeMerites { get; set; }

        static private void MethodeUse()
        {
            Evenement CitoyenEvent = new Evenement();

            Citoyen citoyen = new Citoyen();

            CitoyenEvent.MyEvent += new DelegueEvenement(citoyen.EvenementSurBonheur);

            CitoyenEvent.MyEvent += new DelegueEvenement(citoyen.EvenementSurFertilite);

            CitoyenEvent.MyEvent += new DelegueEvenement(citoyen.EvenementSurPointsDeMerites);

            //Pour l'instant on déclenche l'événement ici
            CitoyenEvent.LancerEvenement();
        }

        public void EvenementSurBonheur(string s)
        {
            Random aleatoire = new Random();

            int alea = aleatoire.Next(100);
            
            Bonheur = Bonheur - alea;


        }

        public void EvenementSurFertilite(string s)
        {
            Random aleatoire = new Random();

            int alea = aleatoire.Next(100);

            Fertilite = Fertilite - (int)(alea/4);


        }

        public void EvenementSurPointsDeMerites(string s)
        {
            Random aleatoire = new Random();

            int alea = aleatoire.Next(100);

            PointsDeMerites = PointsDeMerites - (int)(alea / 8);


        }
    }
}