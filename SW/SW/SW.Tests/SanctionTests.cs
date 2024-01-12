using System;
using Xunit;
using SW.Models;

public class SanctionTests
{
    [Fact]
    public void TestCreationSanction()
    {
        Citoyen infligePar = new Citoyen { Id = 1, Nom = "Skywalker", Prenom = "Luke" };
        Citoyen infligeA = new Citoyen { Id = 2, Nom = "Organa", Prenom = "Leia" };

        Sanction sanction = new Sanction
        {
            Id = 1,
            Date = DateTime.Now,
            MalusMerite = 5,
            InfligePar = infligePar,
            InfligeA = infligeA
        };

        // Vérifier les valeurs des propriétés
        Assert.Equal(1, sanction.Id);
        Assert.True(sanction.Date <= DateTime.Now);
        Assert.Equal(5, sanction.MalusMerite);
        Assert.Equal(infligePar, sanction.InfligePar);
        Assert.Equal(infligeA, sanction.InfligeA);
    }
}
