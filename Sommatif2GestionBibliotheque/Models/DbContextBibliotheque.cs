using Microsoft.EntityFrameworkCore;
using Sommatif2GestionBibliotheque.Models;

namespace Sommatif2GestionBibliotheque.Models
{
    public class DbContextBibliotheque : DbContext
    {
        // Ctor sans paramètre : utilisé par EF Tools et par ton service
        public DbContextBibliotheque()
        {
        }

        // Ctor avec options : utile si un jour tu veux DI
        public DbContextBibliotheque(DbContextOptions<DbContextBibliotheque> options)
            : base(options)
        {
        }

        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<DetailsLivre> DetailsLivres { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<LivreCategorie> LivreCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;" +
                    "Database=GestionBibliothequeDb;" +
                    "Trusted_Connection=True;" +
                    "MultipleActiveResultSets=true;" +
                    "TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1–1 Livre <-> DetailsLivre
            modelBuilder.Entity<Livre>()
                        .HasOne(l => l.DetailsLivre)
                        .WithOne(d => d.Livre)
                        .HasForeignKey<DetailsLivre>(d => d.LivreId);

            // n–n Livre <-> Categorie via LivreCategorie
            modelBuilder.Entity<LivreCategorie>()
                        .HasKey(lc => new { lc.LivreId, lc.CategorieId });

            modelBuilder.Entity<LivreCategorie>()
                        .HasOne(lc => lc.Livre)
                        .WithMany(l => l.LivreCategories)
                        .HasForeignKey(lc => lc.LivreId);

            modelBuilder.Entity<LivreCategorie>()
                        .HasOne(lc => lc.Categorie)
                        .WithMany(c => c.LivreCategories)
                        .HasForeignKey(lc => lc.CategorieId);

            // === Changement des données initiales ===
            modelBuilder.Entity<Auteur>().HasData(AjoutLivres.GetAuteurs());
            modelBuilder.Entity<Categorie>().HasData(AjoutLivres.GetCategories());
            modelBuilder.Entity<Livre>().HasData(AjoutLivres.GetLivres());
            modelBuilder.Entity<DetailsLivre>().HasData(AjoutLivres.GetDetails());
            modelBuilder.Entity<LivreCategorie>().HasData(AjoutLivres.GetLivreCategories());
        }
    }
}