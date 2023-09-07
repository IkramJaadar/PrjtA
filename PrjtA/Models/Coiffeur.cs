
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjtA.Models
{
    public class Coiffeur
    {
        [Key]
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Telephone { get; set; }
        public string? Specialite { get; set; }
        public Boolean RememberMe { get; set; }
        [NotMapped]
        [DisplayName("Nouveau Mot de Passe")]
        [DataType(DataType.Password)]
        
        public string? NouvPass { get; set; }
        [NotMapped]
        [DisplayName("Confirmation mot de Passe")]
        [DataType(DataType.Password)]
        public string? ConfPass { get; set; }
        public List<Sliders>? Sliders { get; set; }
        public List<Service>? Services { get; set; }

    }
}
