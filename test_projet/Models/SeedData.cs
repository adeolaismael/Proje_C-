using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test_projet.Data;
using System;
using System.Linq;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace test_projet.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new test_projetContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<test_projetContext>>()))
            {
                // context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                // S’il y a déjà des films dans la base
                if (context.Continent.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Continent.AddRange(
                new Continent
                {
                    Name = "Africa"
                }
                );


                if (context.Countrie.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Countrie.AddRange(
                new Countrie
                {
                    Country_name = "Cameroon",
                    Id_Continent = 1
                }
                );


                if (context.Pop.Any())
                {
                    return; // On ne fait rien
                }
                // Sinon on en ajoute un
                context.Pop.AddRange(
                new Pop
                {
                    Nbre_pop = 20000000,
                    Annee = 2023,
                    Id_country = 1

                }
                );
                context.SaveChanges();
            }
        }
    }
}
