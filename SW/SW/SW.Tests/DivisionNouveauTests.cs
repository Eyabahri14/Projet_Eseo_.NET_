using System;
using System.Linq;
using Xunit;
using SW.Models;
using SW.Services;
using System.Collections.Generic;

public class DivisionNouveauTests
{
    
    public void TestAddNouveau()
    {
        // Arrange
        var divisionNouveau = new DivisionNouveau();
        Nouveau nouveau = new Nouveau { Id = 1, Nom = "Nouveau1", Prenom = "Test" };

        // Act
        divisionNouveau.AddNouveau(nouveau);

        // Assert
        Assert.Contains(nouveau, divisionNouveau.Nouveaux);
    }

    
    public void TestGetNouveau()
    {
        // Arrange
        var divisionNouveau = new DivisionNouveau();
        Nouveau expectedNouveau = new Nouveau { Id = 1, Nom = "Nouveau1", Prenom = "Test" };
        divisionNouveau.Nouveaux.Add(expectedNouveau);

        // Act
        var result = divisionNouveau.GetNouveau(1);

        // Assert
        Assert.Equal(expectedNouveau, result);
    }

    
    public void TestRemoveNouveau()
    {
        // Arrange
        var divisionNouveau = new DivisionNouveau();
        Nouveau nouveauToRemove = new Nouveau { Id = 1, Nom = "Nouveau1", Prenom = "Test" };
        divisionNouveau.Nouveaux.Add(nouveauToRemove);

        // Act
        divisionNouveau.RemoveNouveau(1);

        // Assert
        Assert.DoesNotContain(nouveauToRemove, divisionNouveau.Nouveaux);
    }

    
    public void TestAddDistinction_NonNouveau()
    {
        // Arrange
        var divisionNouveau = new DivisionNouveau();
        Distinction distinction = new Distinction { Id = 1, Date = DateTime.Now, BonusMerite = 5, DecernePar = new Citoyen(), DecerneA = new Citoyen() };

        // Act
        divisionNouveau.AddDistinction(distinction);

        // Assert
        // La méthode doit simplement retourner sans effectuer d'opération
    }

    
    public void TestAddSanction()
    {
        // Arrange
        var divisionNouveau = new DivisionNouveau();
        Sanction sanction = new Sanction { Id = 1, Date = DateTime.Now, MalusMerite = 2, InfligePar = new Citoyen(), InfligeA = new Nouveau() };

        // Act
        divisionNouveau.AddSanction(sanction);

        // Assert
        // La méthode doit simplement retourner sans effectuer d'opération
    }
}
