using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2GestionBibliotheque.Models
{
    public class LivreCategorie
    {
        public int LivreId { get; set; }
        public Livre Livre { get; set; } = null!;

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = null!;
    }
}
