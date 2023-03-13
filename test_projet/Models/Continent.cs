using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace test_projet.Models
{
    public class Continent
    {

        public int Id { get; set; }

        [Required] public string Name { get; set; }
        public ICollection<Countrie> List_Country { get; set; }
}
}
