using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2GestionBibliotheque.Models
{
    public class DetailsLivre
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public int NombrePages { get; set; }

        public int LivreId { get; set; }
        public Livre Livre { get; set; } = null!;
    }
}
