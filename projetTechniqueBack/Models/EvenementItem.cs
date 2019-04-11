using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetTechniqueBack.Models
{
    public class EvenementItem
    {
        public long Id { get; set; }
        public string Titre { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
