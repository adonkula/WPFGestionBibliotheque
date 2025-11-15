using Microsoft.EntityFrameworkCore;
using Sommatif2GestionBibliotheque.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Sommatif2GestionBibliotheque.Services
{
    public class BibliothequeService
    {
        private readonly DbContextBibliotheque _context;

        public BibliothequeService()
        {
            _context = new DbContextBibliotheque();
        }

        // ========== LECTURE ==========

        // Détails pour l’onglet "Détails Livres"
        public List<CatalogueItem> GetCatalogue()
        {
            return _context.Livres
                .Include(l => l.Auteur)
                .Include(l => l.DetailsLivre)
                .Include(l => l.LivreCategories)
                    .ThenInclude(lc => lc.Categorie)
                .Select(l => new CatalogueItem
                {
                    LivreId = l.Id,
                    Titre = l.Titre,
                    Auteur = l.Auteur.Nom + " " + l.Auteur.Prenom,
                    Categories = string.Join(", ",
                        l.LivreCategories.Select(lc => lc.Categorie.Nom)),
                    ISBN = l.DetailsLivre.ISBN,
                    DatePublication = l.DatePublication,
                    NombrePages = l.DetailsLivre.NombrePages
                })
                .ToList();
        }

        public List<Livre> GetLivres()
        {
            return _context.Livres
                .Include(l => l.Auteur)
                .Include(l => l.DetailsLivre)
                .Include(l => l.LivreCategories)
                    .ThenInclude(lc => lc.Categorie)
                .ToList();
        }

        public List<Auteur> GetAuteurs()
        {
            return _context.Auteurs
                .Include(a => a.Livres)
                .ToList();
        }

        public List<Categorie> GetCategories()
        {
            return _context.Categories
                .Include(c => c.LivreCategories)
                .ToList();
        }

        // ========== ECRITURE ==========

        /// <summary>
        /// Ajout ou modification d’un livre + détails + catégories.
        /// </summary>
        public void AddOrUpdateLivreComplet(
            int? idLivre,
            string titre,
            DateTime datePublication,
            int auteurId,
            string isbn,
            int nombrePages,
            IEnumerable<int> categoriesIds)
        {
            Livre livre;

            if (idLivre.HasValue)
            {
                livre = _context.Livres
                    .Include(l => l.DetailsLivre)
                    .Include(l => l.LivreCategories)
                    .First(l => l.Id == idLivre.Value);

                livre.Titre = titre;
                livre.DatePublication = datePublication;
                livre.AuteurId = auteurId;
            }
            else
            {
                livre = new Livre
                {
                    Titre = titre,
                    DatePublication = datePublication,
                    AuteurId = auteurId,
                    DetailsLivre = new DetailsLivre()
                };

                _context.Livres.Add(livre);
            }

            // Détails
            if (livre.DetailsLivre == null)
            {
                livre.DetailsLivre = new DetailsLivre();
            }

            livre.DetailsLivre.ISBN = isbn;
            livre.DetailsLivre.NombrePages = nombrePages;

            // Catégories
            if (livre.LivreCategories == null)
                livre.LivreCategories = new List<LivreCategorie>();

            livre.LivreCategories.Clear();

            foreach (var catId in categoriesIds)
            {
                livre.LivreCategories.Add(new LivreCategorie
                {
                    // On lie par navigation, EF remplira LivreId automatiquement
                    Livre = livre,
                    CategorieId = catId
                });
            }

            _context.SaveChanges();
        }

        public void DeleteLivre(int idLivre)
        {
            var livre = _context.Livres
                .Include(l => l.DetailsLivre)
                .Include(l => l.LivreCategories)
                .FirstOrDefault(l => l.Id == idLivre);

            if (livre == null) return;

            _context.DetailsLivres.Remove(livre.DetailsLivre);
            _context.LivreCategories.RemoveRange(livre.LivreCategories);
            _context.Livres.Remove(livre);

            _context.SaveChanges();
        }

        // ==================== GESTION AUTEURS ====================

        public Auteur AddOrUpdateAuteur(int? idAuteur, string nom, string prenom)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentException("Le nom de l'auteur est obligatoire.", nameof(nom));

            if (string.IsNullOrWhiteSpace(prenom))
                throw new ArgumentException("Le prénom de l'auteur est obligatoire.", nameof(prenom));

            Auteur auteur;

            if (idAuteur.HasValue)
            {
                auteur = _context.Auteurs.First(a => a.Id == idAuteur.Value);
                auteur.Nom = nom;
                auteur.Prenom = prenom;
            }
            else
            {
                auteur = new Auteur
                {
                    Nom = nom,
                    Prenom = prenom
                };
                _context.Auteurs.Add(auteur);
            }

            _context.SaveChanges();
            return auteur;
        }

        /// <summary>
        /// Supprime un auteur s'il n'a pas de livres.
        /// Retourne false si suppression impossible (auteur relié à des livres).
        /// </summary>
        public bool DeleteAuteur(int idAuteur)
        {
            var auteur = _context.Auteurs
                .Include(a => a.Livres)
                .FirstOrDefault(a => a.Id == idAuteur);

            if (auteur == null)
                return false;

            if (auteur.Livres != null && auteur.Livres.Any())
            {
                // On ne supprime pas un auteur avec des livres liés
                return false;
            }

            _context.Auteurs.Remove(auteur);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Recherche simple par nom/prénom (contient).
        /// </summary>
        public List<Auteur> FindAuteurs(string? nom, string? prenom)
        {
            var query = _context.Auteurs
                .Include(a => a.Livres)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(nom))
                query = query.Where(a => a.Nom.Contains(nom));

            if (!string.IsNullOrWhiteSpace(prenom))
                query = query.Where(a => a.Prenom.Contains(prenom));

            return query.ToList();
        }

        // ==================== GESTION CATÉGORIES ====================

        public Categorie AddOrUpdateCategorie(int? idCategorie, string nom)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentException("Le nom de la catégorie est obligatoire.", nameof(nom));

            Categorie categorie;

            if (idCategorie.HasValue)
            {
                categorie = _context.Categories.First(c => c.Id == idCategorie.Value);
                categorie.Nom = nom;
            }
            else
            {
                categorie = new Categorie
                {
                    Nom = nom
                };
                _context.Categories.Add(categorie);
            }

            _context.SaveChanges();
            return categorie;
        }

        /// <summary>
        /// Supprime une catégorie si aucun livre n'y est associé.
        /// Retourne false si suppression impossible.
        /// </summary>
        public bool DeleteCategorie(int idCategorie)
        {
            var categorie = _context.Categories
                .Include(c => c.LivreCategories)
                .FirstOrDefault(c => c.Id == idCategorie);

            if (categorie == null)
                return false;

            if (categorie.LivreCategories != null && categorie.LivreCategories.Any())
            {
                // Il y a des livres associés -> on bloque
                return false;
            }

            _context.Categories.Remove(categorie);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Recherche simple par nom (contient).
        /// </summary>
        public List<Categorie> FindCategories(string? nom)
        {
            var query = _context.Categories
                .Include(c => c.LivreCategories)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(nom))
                query = query.Where(c => c.Nom.Contains(nom));

            return query.ToList();
        }

    }
}
