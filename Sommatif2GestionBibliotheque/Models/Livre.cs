using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sommatif2GestionBibliotheque.Models
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public DateTime DatePublication { get; set; }

        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; } = null!;

        // 1–1 avec DetailsLivre
        public DetailsLivre DetailsLivre { get; set; } = null!;

        // n–n avec Categorie via LivreCategorie
        public ICollection<LivreCategorie> LivreCategories { get; set; } = new List<LivreCategorie>();

        public string CategoriesText => string.Join(", ", LivreCategories.Select(lc => lc.Categorie.Nom));
        // Pour la grille des livres (liste des catégories)
        public string CategoriesConcat =>
            string.Join(", ", LivreCategories.Select(lc => lc.Categorie?.Nom).Where(n => !string.IsNullOrWhiteSpace(n)));
    }
}
