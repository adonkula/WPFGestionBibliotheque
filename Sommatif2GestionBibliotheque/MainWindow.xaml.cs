using Sommatif2GestionBibliotheque.Models;
using Sommatif2GestionBibliotheque.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sommatif2GestionBibliotheque
{
    public partial class MainWindow : Window
    {
        private readonly BibliothequeService _service;
        private Livre? _livreEnEdition;
        private Auteur? _auteurEnEdition;
        private Categorie? _categorieEnEdition;

        private List<Auteur> _auteurs = new();
        private List<Categorie> _categories = new();

        public MainWindow()
        {
            InitializeComponent();

            _service = new BibliothequeService();

            // Langue par défaut : FR
            cbLang.SelectedIndex = 0; // sélectionne "Français"
            ChangeLanguage("fr");

            // Charger toutes les données
            ChargerDonnees();
        }

        // ====== StatusBar ======

        private void SetStatus(string message)
        {
            sbStatus.Text = message;
        }

        /// <summary>
        /// Met à jour la StatusBar avec le nombre de lignes dans
        /// "Détails livres" et "Livres". On peut ajouter un préfixe.
        /// </summary>
        private void UpdateCountsInStatus(string? prefixMessage = null)
        {
            int nbDetails = dgCatalogue.Items.Count;
            int nbLivres = dgLivres.Items.Count;

            string counts = $"{nbDetails} enregistrement(s) dans \"Détails livres\" • {nbLivres} livre(s)";

            if (string.IsNullOrWhiteSpace(prefixMessage))
                SetStatus(counts);
            else
                SetStatus($"{prefixMessage} — {counts}");
        }

        // ====== Rafraîchissement des headers pour la langue ======

        private void RafraichirHeadersGrilles()
        {
            // ===== Détails livres (dgCatalogue) =====
            if (dgCatalogue.Columns.Count >= 6)
            {
                dgCatalogue.Columns[0].Header = TryFindResource("Lbl_Title") ?? "Titre";
                dgCatalogue.Columns[1].Header = TryFindResource("Lbl_Author") ?? "Auteur";
                dgCatalogue.Columns[2].Header = TryFindResource("Lbl_Category") ?? "Catégorie";
                dgCatalogue.Columns[3].Header = TryFindResource("Lbl_ISBN") ?? "ISBN";
                dgCatalogue.Columns[4].Header = TryFindResource("Lbl_PubDate") ?? "Date de publication";
                dgCatalogue.Columns[5].Header = TryFindResource("Lbl_PageCount") ?? "Nombre de pages";
            }

            // ===== Livres (dgLivres) =====
            if (dgLivres.Columns.Count >= 6)
            {
                dgLivres.Columns[0].Header = TryFindResource("Lbl_Title") ?? "Titre";
                dgLivres.Columns[1].Header = TryFindResource("Lbl_Author") ?? "Auteur";
                dgLivres.Columns[2].Header = TryFindResource("Lbl_Category") ?? "Catégorie";
                dgLivres.Columns[3].Header = TryFindResource("Lbl_ISBN") ?? "ISBN";
                dgLivres.Columns[4].Header = TryFindResource("Lbl_PubDate") ?? "Date de publication";
                dgLivres.Columns[5].Header = TryFindResource("Lbl_PageCount") ?? "Nombre de pages";
            }

            // ===== Auteurs (dgAuteurs) =====
            if (dgAuteurs.Columns.Count >= 3)
            {
                dgAuteurs.Columns[0].Header = TryFindResource("Lbl_LastName") ?? "Nom";
                dgAuteurs.Columns[1].Header = TryFindResource("Lbl_FirstName") ?? "Prénom";
                dgAuteurs.Columns[2].Header = TryFindResource("Lbl_BookCount") ?? "Nombre de livres";
            }

            // ===== Catégories (dgCategories) =====
            if (dgCategories.Columns.Count >= 2)
            {
                dgCategories.Columns[0].Header = TryFindResource("Lbl_CategoryName") ?? "Nom";
                dgCategories.Columns[1].Header = TryFindResource("Lbl_CategoryBookCount") ?? "Nombre de livres associés";
            }
        }

        /// <summary>
        /// Recharge toutes les listes (catalogue, livres, auteurs, catégories)
        /// et met à jour les contrôles (DataGrid, ComboBox, ListBox).
        /// </summary>
        private void ChargerDonnees()
        {
            // Charger depuis le service
            var catalogue = _service.GetCatalogue();
            var livres = _service.GetLivres();
            _auteurs = _service.GetAuteurs();
            _categories = _service.GetCategories();

            // Lier aux DataGrid
            dgCatalogue.ItemsSource = catalogue;
            dgLivres.ItemsSource = livres;
            dgAuteurs.ItemsSource = _auteurs;
            dgCategories.ItemsSource = _categories;

            // Lier ComboBox / ListBox de l’onglet Livres
            cbAuteurLiv.ItemsSource = _auteurs;
            lbCategoriesLiv.ItemsSource = _categories;

            // Mettre à jour la StatusBar avec les compteurs
            UpdateCountsInStatus();
        }

        // ====== Sélections dans les DataGrid ======

        private void dgLivres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgLivres.SelectedItem is not Livre livre)
                return;

            _livreEnEdition = livre;

            // Remplir les champs
            tbTitreLiv.Text = livre.Titre;
            tbDatePubLiv.Text = livre.DatePublication.ToShortDateString();
            tbIsbnLiv.Text = livre.DetailsLivre?.ISBN ?? string.Empty;
            tbNbrLiv.Text = livre.DetailsLivre?.NombrePages.ToString() ?? string.Empty;

            // Auteur
            cbAuteurLiv.SelectedValue = livre.AuteurId;

            // Catégories
            lbCategoriesLiv.SelectedItems.Clear();
            foreach (var lc in livre.LivreCategories)
            {
                var cat = _categories.FirstOrDefault(c => c.Id == lc.CategorieId);
                if (cat != null)
                    lbCategoriesLiv.SelectedItems.Add(cat);
            }
        }

        private void dgAuteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAuteurs.SelectedItem is not Auteur auteur)
                return;

            _auteurEnEdition = auteur;

            tbNomAut.Text = auteur.Nom;
            tbPrenomAut.Text = auteur.Prenom;
            tbNbrAut.Text = auteur.NombreLivres.ToString();
        }

        private void dgCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCategories.SelectedItem is not Categorie categorie)
                return;

            _categorieEnEdition = categorie;

            tbNomCat.Text = categorie.Nom;
            tbNbrCat.Text = categorie.NombreLivres.ToString();
        }

        /// <summary>
        /// Ajout ou modification d’un livre complet (Livre + DetailsLivre + catégories).
        /// </summary>
        private void EnregistrerLivreDepuisFormulaire(bool estModification)
        {
            // 1. Récupérer auteur
            if (cbAuteurLiv.SelectedValue is not int auteurId)
            {
                MessageBox.Show("Veuillez sélectionner un auteur.");
                SetStatus("Auteur non sélectionné.");
                return;
            }

            // 2. Récupérer catégories sélectionnées
            var categoriesIds = lbCategoriesLiv.SelectedItems
                .Cast<Categorie>()
                .Select(c => c.Id)
                .ToList();

            // 3. Récupérer les autres champs
            if (!DateTime.TryParse(tbDatePubLiv.Text, out var datePub))
            {
                MessageBox.Show("Date de publication invalide.");
                SetStatus("Date de publication invalide.");
                return;
            }

            if (!int.TryParse(tbNbrLiv.Text, out var pages))
            {
                MessageBox.Show("Nombre de pages invalide.");
                SetStatus("Nombre de pages invalide.");
                return;
            }

            string titre = tbTitreLiv.Text.Trim();
            string isbn = tbIsbnLiv.Text.Trim();

            if (string.IsNullOrWhiteSpace(titre))
            {
                MessageBox.Show("Le titre est obligatoire.");
                SetStatus("Le titre du livre est obligatoire.");
                return;
            }

            try
            {
                // 4. Appeler le service (ajout ou modification)
                _service.AddOrUpdateLivreComplet(
                    idLivre: estModification ? _livreEnEdition?.Id : null,
                    titre: titre,
                    datePublication: datePub,
                    auteurId: auteurId,
                    isbn: isbn,
                    nombrePages: pages,
                    categoriesIds: categoriesIds
                );

                // 5. Rafraîchir l’écran
                ChargerDonnees();
                ViderFormulaireLivres();

                string action = estModification ? "modifié" : "ajouté";
                UpdateCountsInStatus($"Livre {action} avec succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement du livre : " + ex.Message);
                SetStatus("Erreur lors de l'enregistrement du livre.");
            }
        }

        private void ViderFormulaireLivres()
        {
            tbTitreLiv.Text = "";
            tbDatePubLiv.Text = "";
            tbIsbnLiv.Text = "";
            tbNbrLiv.Text = "";
            cbAuteurLiv.SelectedIndex = -1;
            lbCategoriesLiv.SelectedItems.Clear();
            _livreEnEdition = null;
        }

        private void btnViderLiv_Click(object sender, RoutedEventArgs e)
        {
            ViderFormulaireLivres();
            SetStatus("Formulaire livre vidé.");
        }

        // ==================== GESTION LANGUE ====================

        private void cbLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLang.SelectedItem is ComboBoxItem item)
            {
                var tag = item.Tag as string;
                string lang = string.IsNullOrWhiteSpace(tag) ? "fr" : tag; // "fr" ou "en"

                ChangeLanguage(lang);
            }
        }

        private void ChangeLanguage(string lang)
        {
            if (string.IsNullOrWhiteSpace(lang))
                lang = "fr";

            try
            {
                var dict = new ResourceDictionary();

                if (lang == "en")
                    dict.Source = new Uri("Resources/Strings.en.xaml", UriKind.Relative);
                else
                    dict.Source = new Uri("Resources/Strings.fr.xaml", UriKind.Relative);

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dict);

                // Met à jour les entêtes des DataGrid
                RafraichirHeadersGrilles();

                // Met à jour la StatusBar
                UpdateCountsInStatus($"Langue changée en {(lang == "en" ? "anglais" : "français")}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du changement de langue : " + ex.Message);
                SetStatus("Erreur lors du changement de langue.");
            }
        }

        // ==================== BOUTONS LIVRES ====================

        private void btnAjouterLiv_Click(object sender, RoutedEventArgs e)
        {
            _livreEnEdition = null; // nouveau livre
            EnregistrerLivreDepuisFormulaire(estModification: false);
        }

        private void btnModifierLiv_Click(object sender, RoutedEventArgs e)
        {
            if (_livreEnEdition == null && dgLivres.SelectedItem is Livre livreSelectionne)
            {
                _livreEnEdition = livreSelectionne;
            }

            if (_livreEnEdition == null)
            {
                MessageBox.Show("Sélectionnez un livre à modifier.");
                SetStatus("Aucun livre sélectionné pour la modification.");
                return;
            }

            EnregistrerLivreDepuisFormulaire(estModification: true);
        }

        private void btnSupprimerLiv_Click(object sender, RoutedEventArgs e)
        {
            if (dgLivres.SelectedItem is not Livre livre)
            {
                MessageBox.Show("Sélectionnez un livre à supprimer.");
                SetStatus("Aucun livre sélectionné pour la suppression.");
                return;
            }

            if (MessageBox.Show("Supprimer ce livre ?", "Confirmation",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _service.DeleteLivre(livre.Id);
                ChargerDonnees();
                ViderFormulaireLivres();
                UpdateCountsInStatus("Livre supprimé avec succès");
            }
        }

        // ==================== RECHERCHE LIVRES ====================

        private void btnRechercherLiv_Click(object sender, RoutedEventArgs e)
        {
            string filtreTitre = tbTitreLiv.Text.Trim();
            string filtreIsbn = tbIsbnLiv.Text.Trim();

            var livres = _service.GetLivres();

            var resultats = livres.Where(l =>
                (string.IsNullOrWhiteSpace(filtreTitre)
                    || l.Titre.Contains(filtreTitre, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtreIsbn)
                    || (l.DetailsLivre != null
                        && l.DetailsLivre.ISBN.Contains(filtreIsbn, StringComparison.OrdinalIgnoreCase)))
            ).ToList();

            dgLivres.ItemsSource = resultats;

            SetStatus($"{resultats.Count} livre(s) correspondant(s) au filtre.");
        }

        // ==================== AUTEURS ====================

        private void EnregistrerAuteurDepuisFormulaire()
        {
            string nom = tbNomAut.Text.Trim();
            string prenom = tbPrenomAut.Text.Trim();

            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom))
            {
                MessageBox.Show("Nom et prénom de l'auteur sont obligatoires.");
                SetStatus("Nom ou prénom d'auteur manquant.");
                return;
            }

            try
            {
                _service.AddOrUpdateAuteur(
                    idAuteur: _auteurEnEdition?.Id,
                    nom: nom,
                    prenom: prenom
                );

                ChargerDonnees();
                ViderFormulaireAuteurs();

                string action = _auteurEnEdition == null ? "ajouté" : "modifié";
                UpdateCountsInStatus($"Auteur {action} avec succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de l'auteur : " + ex.Message);
                SetStatus("Erreur lors de l'enregistrement de l'auteur.");
            }
        }

        private void ViderFormulaireAuteurs()
        {
            tbNomAut.Text = string.Empty;
            tbPrenomAut.Text = string.Empty;
            tbNbrAut.Text = string.Empty;
            _auteurEnEdition = null;
        }

        private void btnAjouterAut_Click(object sender, RoutedEventArgs e)
        {
            _auteurEnEdition = null;
            EnregistrerAuteurDepuisFormulaire();
        }

        private void btnModifierAut_Click(object sender, RoutedEventArgs e)
        {
            if (_auteurEnEdition == null && dgAuteurs.SelectedItem is Auteur auteurSelectionne)
            {
                _auteurEnEdition = auteurSelectionne;
            }

            if (_auteurEnEdition == null)
            {
                MessageBox.Show("Sélectionnez un auteur à modifier.");
                SetStatus("Aucun auteur sélectionné pour la modification.");
                return;
            }

            EnregistrerAuteurDepuisFormulaire();
        }

        private void btnSupprimerAut_Click(object sender, RoutedEventArgs e)
        {
            if (dgAuteurs.SelectedItem is not Auteur auteur)
            {
                MessageBox.Show("Sélectionnez un auteur à supprimer.");
                SetStatus("Aucun auteur sélectionné pour la suppression.");
                return;
            }

            if (MessageBox.Show("Supprimer cet auteur ?", "Confirmation",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            var ok = _service.DeleteAuteur(auteur.Id);

            if (!ok)
            {
                MessageBox.Show("Impossible de supprimer un auteur qui possède des livres.");
                SetStatus("Suppression auteur refusée : des livres lui sont associés.");
                return;
            }

            ChargerDonnees();
            ViderFormulaireAuteurs();
            UpdateCountsInStatus("Auteur supprimé avec succès");
        }

        private void btnRechercherAut_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbNomAut.Text.Trim();
            string prenom = tbPrenomAut.Text.Trim();

            var resultats = _service.FindAuteurs(nom, prenom);

            dgAuteurs.ItemsSource = resultats;

            if (resultats.Count == 1)
            {
                tbNbrAut.Text = (resultats[0].Livres?.Count ?? 0).ToString();
            }

            SetStatus($"{resultats.Count} auteur(s) trouvé(s).");
        }

        private void btnViderAut_Click(object sender, RoutedEventArgs e)
        {
            ViderFormulaireAuteurs();
            dgAuteurs.SelectedItem = null;
            dgAuteurs.ItemsSource = _auteurs;
            SetStatus("Formulaire auteurs vidé. Liste complète rétablie.");
        }

        // ==================== CATÉGORIES ====================

        private void EnregistrerCategorieDepuisFormulaire()
        {
            string nom = tbNomCat.Text.Trim();

            if (string.IsNullOrWhiteSpace(nom))
            {
                MessageBox.Show("Le nom de la catégorie est obligatoire.");
                SetStatus("Nom de catégorie manquant.");
                return;
            }

            try
            {
                _service.AddOrUpdateCategorie(
                    idCategorie: _categorieEnEdition?.Id,
                    nom: nom
                );

                ChargerDonnees();
                ViderFormulaireCategories();

                string action = _categorieEnEdition == null ? "ajoutée" : "modifiée";
                UpdateCountsInStatus($"Catégorie {action} avec succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement de la catégorie : " + ex.Message);
                SetStatus("Erreur lors de l'enregistrement de la catégorie.");
            }
        }

        private void ViderFormulaireCategories()
        {
            tbNomCat.Text = string.Empty;
            tbNbrCat.Text = string.Empty;
            _categorieEnEdition = null;
        }

        private void btnAjouterCatg_Click(object sender, RoutedEventArgs e)
        {
            _categorieEnEdition = null;   // nouvelle catégorie
            EnregistrerCategorieDepuisFormulaire();
        }

        private void btnModifierCatg_Click(object sender, RoutedEventArgs e)
        {
            if (_categorieEnEdition == null && dgCategories.SelectedItem is Categorie catSelectionnee)
            {
                _categorieEnEdition = catSelectionnee;
            }

            if (_categorieEnEdition == null)
            {
                MessageBox.Show("Sélectionnez une catégorie à modifier.");
                SetStatus("Aucune catégorie sélectionnée pour la modification.");
                return;
            }

            EnregistrerCategorieDepuisFormulaire();
        }

        private void btnSupprimerCatg_Click(object sender, RoutedEventArgs e)
        {
            if (dgCategories.SelectedItem is not Categorie cat)
            {
                MessageBox.Show("Sélectionnez une catégorie à supprimer.");
                SetStatus("Aucune catégorie sélectionnée pour la suppression.");
                return;
            }

            if (MessageBox.Show("Supprimer cette catégorie ?", "Confirmation",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            var ok = _service.DeleteCategorie(cat.Id);

            if (!ok)
            {
                MessageBox.Show("Impossible de supprimer une catégorie qui est associée à des livres.");
                SetStatus("Suppression catégorie refusée : des livres y sont associés.");
                return;
            }

            ChargerDonnees();
            ViderFormulaireCategories();
            UpdateCountsInStatus("Catégorie supprimée avec succès");
        }

        private void btnRechercherCatg_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbNomCat.Text.Trim();

            var resultats = _service.FindCategories(nom);

            dgCategories.ItemsSource = resultats;

            if (resultats.Count == 1)
            {
                tbNbrCat.Text = (resultats[0].LivreCategories?.Count ?? 0).ToString();
            }

            SetStatus($"{resultats.Count} catégorie(s) trouvée(s).");
        }

        private void btnViderCatg_Click(object sender, RoutedEventArgs e)
        {
            ViderFormulaireCategories();
            dgCategories.ItemsSource = _categories;
            SetStatus("Formulaire catégories vidé. Liste complète rétablie.");
        }
    }
}
