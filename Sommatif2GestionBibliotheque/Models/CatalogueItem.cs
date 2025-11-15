using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2GestionBibliotheque.Models
{
    /// <summary>
    /// Vue de lecture pour l’onglet "Détails Livres".
    /// Ne correspond pas à une table, juste à un SELECT avec des JOIN.
    /// </summary>
    public class CatalogueItem
    {
        public int LivreId { get; set; }

        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateTime DatePublication { get; set; }
        public int NombrePages { get; set; }
    }
}

