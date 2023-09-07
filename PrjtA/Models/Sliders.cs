using System.ComponentModel.DataAnnotations;

namespace PrjtA.Models
{
    public class Sliders
    {
        [Key]
        public int Num { get; set; }
        public string? Contenu { get; set; }
        public Coiffeur? coiffeur { get; set; }
        public int? CoiffeurId { get; set; }
    }
}
