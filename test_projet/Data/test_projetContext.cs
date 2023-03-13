using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_projet.Models;

namespace test_projet.Data
{
    public class test_projetContext : DbContext
    {
        public test_projetContext (DbContextOptions<test_projetContext> options)
            : base(options)
        {
        }

        public DbSet<test_projet.Models.Continent> Continent { get; set; } = default!;

        public DbSet<test_projet.Models.Countrie> Countrie { get; set; } = default!;

        public DbSet<test_projet.Models.Pop> Pop { get; set; } = default!;
    }
}
