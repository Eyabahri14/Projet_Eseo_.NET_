using Xunit;
using SW.Models;

public class CitoyenTests
{
    
    public void TestCreationCitoyen()
    {
        Citoyen citoyen = new Citoyen();
        Assert.NotNull(citoyen);
        // Vérifier les valeurs des propriétés
        Assert.Equal(0, citoyen.Id);
        Assert.Null(citoyen.Nom);
        Assert.Null(citoyen.Prenom);
        Assert.Equal(0, citoyen.Age);
    }

    
    public void TestAffectationValeurs()
    {
        // Créer une instance d'Espece pour l'assigner au Citoyen
        Espece especeHumain = new Espece { Id = 1, Nom = "Humain", Longevite = 80, Majorite = 18 };

        Citoyen citoyen = new Citoyen
        {
            Id = 1,
            Nom = "Skywalker",
            Prenom = "Luke",
            Age = 30,
            Espece = especeHumain,  // Utilisation de la classe Espece
            PereBiologiqueID = 2,
            MereBiologiqueID = 3
        };
        // Vérifier les valeurs des propriétés
        Assert.Equal(1, citoyen.Id);
        Assert.Equal("Skywalker", citoyen.Nom);
        Assert.Equal("Luke", citoyen.Prenom);
        Assert.Equal(30, citoyen.Age);
        Assert.Equal(especeHumain, citoyen.Espece);
        Assert.Equal(2, citoyen.PereBiologiqueID);
        Assert.Equal(3, citoyen.MereBiologiqueID);
    }

    
    public void TestRelationsCitoyens()
    {
        Espece especeHumain = new Espece { Id = 1, Nom = "Humain", Longevite = 80, Majorite = 18 };

        Citoyen pere = new Citoyen { Id = 2, Nom = "Skywalker", Prenom = "Anakin" };
        Citoyen mere = new Citoyen { Id = 3, Nom = "Amidala", Prenom = "Padmé" };

        Citoyen fils = new Citoyen
        {
            Id = 1,
            Nom = "Skywalker",
            Prenom = "Luke",
            Age = 30,
            Espece = especeHumain,  // Utilisation de la classe Espece
            PereBiologique = pere,
            MereBiologique = mere
        };

        // Vérifier les relations
        Assert.Equal("Luke", fils.Prenom);
        Assert.Equal(pere, fils.PereBiologique);
        Assert.Equal(mere, fils.MereBiologique);
    }
}
