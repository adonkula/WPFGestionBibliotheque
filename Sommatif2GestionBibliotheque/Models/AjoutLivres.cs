using System;
using System.Collections.Generic;

namespace Sommatif2GestionBibliotheque.Models
{
    public static class AjoutLivres
    {
        public static List<Auteur> GetAuteurs()
        {
            return new List<Auteur>
            {
                new Auteur { Id = 1, Nom = "Hugo",       Prenom = "Victor"     },
                new Auteur { Id = 2, Nom = "Zola",       Prenom = "Émile"      },
                new Auteur { Id = 3, Nom = "Dumas",      Prenom = "Alexandre"  },
                new Auteur { Id = 4, Nom = "La Fontaine",Prenom = "Jean"       },
                new Auteur { Id = 5, Nom = "Munroe",     Prenom = "Myles"      }
            };
        }

        public static List<Categorie> GetCategories()
        {
            return new List<Categorie>
            {
                new Categorie { Id = 1, Nom = "Roman" },
                new Categorie { Id = 2, Nom = "Classique" },
                new Categorie { Id = 3, Nom = "Fantastique" },
                new Categorie { Id = 4, Nom = "Histoire" }
            };
        }

        public static List<Livre> GetLivres()
        {
            var livres = new List<Livre>();
            var random = new Random();

            for (int i = 1; i <= 30; i++)
            {
                livres.Add(new Livre
                {
                    Id = i,
                    Titre = $"Livre Test {i}",
                    DatePublication = new DateTime(2000 + random.Next(0, 24), 1, 1),
                    // 1 à 5 : correspond aux 5 auteurs cités plus haut
                    AuteurId = random.Next(1, 6)
                });
            }

            return livres;
        }

        public static List<DetailsLivre> GetDetails()
        {
            var details = new List<DetailsLivre>();

            for (int i = 1; i <= 30; i++)
            {
                details.Add(new DetailsLivre
                {
                    Id = i,
                    LivreId = i,
                    ISBN = $"ISBN-{1000 + i}",
                    NombrePages = 100 + i
                });
            }

            return details;
        }

        public static List<LivreCategorie> GetLivreCategories()
        {
            var list = new List<LivreCategorie>();
            var random = new Random();

            for (int i = 1; i <= 30; i++)
            {
                // chaque livre reçoit 1 ou 2 catégories au hasard
                int cat1 = random.Next(1, 5);
                int cat2 = random.Next(1, 5);

                list.Add(new LivreCategorie { LivreId = i, CategorieId = cat1 });

                if (cat2 != cat1)
                    list.Add(new LivreCategorie { LivreId = i, CategorieId = cat2 });
            }

            return list;
        }
    }
}
