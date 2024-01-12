using System;
using Xunit;
using SW.Models;

public class DistinctionTests
{
    [Fact]
    public void TestCreationDistinction()
    {
        Citoyen decernePar = new Citoyen { Id = 1, Nom = "Skywalker", Prenom = "Luke" };
        Citoyen decerneA = new Citoyen { Id = 2, Nom = "Organa", Prenom = "Leia" };

        Distinction distinction = new Distinction
        {
            Id = 1,
            Date = DateTime.Now,
            BonusMerite = 10,
            DecernePar = decernePar,
            DecerneA = decerneA
        };

        // Vérifier les valeurs des propriétés
        Assert.Equal(1, distinction.Id);
        Assert.True(distinction.Date <= DateTime.Now);
        Assert.Equal(10, distinction.BonusMerite);
        Assert.Equal(decernePar, distinction.DecernePar);
        Assert.Equal(decerneA, distinction.DecerneA);
    }
}
