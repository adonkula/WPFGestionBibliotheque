using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2GestionBibliotheque.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        public ICollection<LivreCategorie> LivreCategories { get; set; } = new List<LivreCategorie>();
        public int NombreLivres => LivreCategories?.Count ?? 0;
    }
}
