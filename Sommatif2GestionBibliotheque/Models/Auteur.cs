using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2GestionBibliotheque.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // Navigation
        public ICollection<Livre> Livres { get; set; } = new List<Livre>();

        // Pour l'affichage dans les listes (ComboBox, DataGrid, etc.)
        public string NomComplet => $"{Nom} {Prenom}".Trim();
        public int NombreLivres => Livres?.Count ?? 0;
    }
}
