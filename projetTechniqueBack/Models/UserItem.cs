using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetTechniqueBack.Models
{
    public class UserItem
    {
        public string Id { get; set; }
        public string Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public decimal Poids { get; set; }
        public decimal Taille { get; set; }
        public bool IsCoach { get; set; }
    }
}
