using System;
using Xunit;
using SW.Models;
using SW.Services;
using SW.DataAccessLayer;
using System.Collections.Generic;

public class DivisionCitoyenTests
{
    
    public void TestAddCitoyen()
    {
        // Arrange
        var repository = new CitoyenRepository();
        var divisionCitoyen = new DivisionCitoyen(repository);

        Citoyen citoyen = new Citoyen
        {
            Id = 1,
            Nom = "Skywalker",
            Prenom = "Luke",
            Age = 30,
            Espece = Espece.Humain,
            PereBiologiqueID = 2,
            MereBiologiqueID = 3
        };

        // Act
        divisionCitoyen.AddCitoyen(citoyen);

        // Assert
        var result = repository.GetCitoyens();
        Assert.Contains(citoyen, result);
    }

    [Fact]
    public void TestGetCitoyens()
    {
        // Arrange
        var repository = new CitoyenRepository();
        var divisionCitoyen = new DivisionCitoyen(repository);

        var expectedCitoyens = new List<Citoyen>
        {
            new Citoyen { Id = 1, Nom = "Skywalker", Prenom = "Luke" },
            new Citoyen { Id = 2, Nom = "Organa", Prenom = "Leia" },
        };

        foreach (var citoyen in expectedCitoyens)
        {
            repository.AddCitoyen(citoyen);
        }

        // Act
        var result = divisionCitoyen.GetCitoyens();

        // Assert
        Assert.Equal(expectedCitoyens, result);
    }
}
