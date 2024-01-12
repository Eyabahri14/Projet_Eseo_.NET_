using System;
using Xunit;
using SW.Models;
using SW.Services;
using SW.DataAccessLayer;
using System.Collections.Generic;

public class EspeceServiceTests
{
    [Fact]
    public void TestAddEspece()
    {
        // Arrange
        var especeRepository = new EspeceRepository();
        var especeService = new EspeceService(especeRepository);
        Espece espece = new Espece { Id = 1, Nom = "Humain", Longevite = 80, Majorite = 18 };

        // Act
        especeService.AddEspece(espece);

        // Assert
        var result = especeRepository.GetAllEspeces();
        Assert.Contains(espece, result);
    }

    [Fact]
    public void TestGetAllEspeces()
    {
        // Arrange
        var especeRepository = new EspeceRepository();
        var especeService = new EspeceService(especeRepository);

        var expectedEspeces = new List<Espece>
        {
            new Espece { Id = 1, Nom = "Humain", Longevite = 80, Majorite = 18 },
            new Espece { Id = 2, Nom = "Alien", Longevite = 100, Majorite = 20 },
        };

        foreach (var espece in expectedEspeces)
        {
            especeRepository.AddEspece(espece);
        }

        // Act
        var result = especeService.GetAllEspeces();

        // Assert
        Assert.Equal(expectedEspeces, result);
    }

    [Fact]
    public void TestGetEspeceById()
    {
        // Arrange
        var especeRepository = new EspeceRepository();
        var especeService = new EspeceService(especeRepository);

        Espece expectedEspece = new Espece { Id = 1, Nom = "Humain", Longevite = 80, Majorite = 18 };
        especeRepository.AddEspece(expectedEspece);

        // Act
        var result = especeService.GetEspeceById(1);

        // Assert
        Assert.Equal(expectedEspece, result);
    }

    [Fact]
    public void TestUpdateEspece()
    {
        // Arrange
        var especeRepository = new EspeceRepository();
        var especeService = new EspeceService(especeRepository);

        Espece especeToUpdate = new Espece { Id = 1, Nom = "Humain", Longevite = 80, Majorite = 18 };
        especeRepository.AddEspece(especeToUpdate);

        Espece updatedEspece = new Espece { Id = 1, Nom = "Humain Modifié", Longevite = 90, Majorite = 20 };

        // Act
        especeService.UpdateEspece(updatedEspece);

        // Assert
        var result = especeRepository.GetEspeceById(1);
        Assert.Equal(updatedEspece, result);
    }

    [Fact]
    public void TestDeleteEspece()
    {
        // Arrange
        var especeRepository = new EspeceRepository();
        var especeService = new EspeceService(especeRepository);

        Espece especeToDelete = new Espece { Id = 1, Nom = "Humain", Longevite = 80, Majorite = 18 };
        especeRepository.AddEspece(especeToDelete);

        // Act
        especeService.DeleteEspece(1);

        // Assert
        var result = especeRepository.GetAllEspeces();
        Assert.DoesNotContain(especeToDelete, result);
    }
}
