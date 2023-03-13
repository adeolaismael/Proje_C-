using System.ComponentModel.DataAnnotations.Schema;

namespace test_projet.Models
{
    public class Countrie
    {
        public int Id { get; set; }
        public string Country_name { get; set; }

        [ForeignKey("Continent")] public int Id_Continent { get; set; }
    }
}
