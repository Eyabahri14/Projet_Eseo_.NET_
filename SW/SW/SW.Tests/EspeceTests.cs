using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Xunit;
using SW.Models;

public class EspeceTests
{
    
    public void TestCreationEspece()
    {
        Espece espece = new Espece
        {
            Id = 1,
            Nom = "Humain",
            Longevite = 80,
            Majorite = 18
        };

        // Vérifier les valeurs des propriétés
        Assert.Equal(1, espece.Id);
        Assert.Equal("Humain", espece.Nom);
        Assert.Equal(80, espece.Longevite);
        Assert.Equal(18, espece.Majorite);
    }
}

