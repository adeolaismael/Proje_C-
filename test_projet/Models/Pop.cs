using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test_projet.Models
{
    public class Pop
    {
        public int Id { get; set; }

        [Required] public int Nbre_pop { get; set; }

        [Required] public int Annee { get; set; }

        [ForeignKey("Countrie")] public int Id_country { get; set; }


    }
}
