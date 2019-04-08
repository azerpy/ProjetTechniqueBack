using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetTechniqueBack.Models
{
    public class ExerciceItem
    {
        public long Id { get; set; }
        public string Titre { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
