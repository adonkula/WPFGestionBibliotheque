# Sommatif2 -- Gestion de la bibliothèque

Application WPF de gestion simplifiée d'une bibliothèque, réalisée dans
le cadre du sommatif 2.\
Elle permet de gérer :

-   les **livres** (avec détails : ISBN, nombre de pages, auteur,
    catégories)\
-   les **auteurs**\
-   les **catégories**\
-   un onglet **Détails livres** qui présente un catalogue synthétique

L'application est bilingue **Français / Anglais** et persiste les
données dans une base **SQL Server LocalDB** via **Entity Framework
Core**.

------------------------------------------------------------------------

## 1. Choix techniques

### 1.1 Interface graphique : WPF

-   **Technologie** : WPF (.NET 9, C#)
-   Contrôles riches : `TabControl`, `DataGrid`, `StatusBar`, etc.

### 1.2 Accès aux données : Entity Framework Core + SQL Server LocalDB

Modèle relationnel : - `Auteurs` (1) → (N) `Livres` - `Livres` (1) → (1)
`DetailsLivres` - `Livres` (N) → (N) `Categories` via `LivreCategories`

### 1.3 Architecture interne

-   `Models/` --- Entités EF Core + DTO\
-   `Services/` --- Logique métier (`BibliothequeService`)\
-   `MainWindow.xaml.cs` --- Gestion des événements + rafraîchissement
    UI + StatusBar

### 1.4 Gestion de la langue (FR / EN)

-   `Resources/Strings.fr.xaml`
-   `Resources/Strings.en.xaml`

Chargement dynamique via :

``` csharp
Application.Current.Resources.MergedDictionaries.Clear();
Application.Current.Resources.MergedDictionaries.Add(dict);
```

### 1.5 Status bar

Affiche : - le nombre de lignes dans les DataGrid - messages sur les
opérations (ajout, modification, suppression)

------------------------------------------------------------------------

## 2. Captures d'écran

*(Remplacer par vos propres images dans docs/)*

-   `docs/capture-details-livres.png`
-   `docs/capture-livres.png`
-   `docs/capture-auteurs.png`
-   `docs/capture-categories.png`

------------------------------------------------------------------------

## 3. Lancement du projet

1.  Ouvrir la solution.
2.  `Update-Database` pour appliquer les migrations.
3.  Exécuter (F5).

------------------------------------------------------------------------

## 4. Pistes d'amélioration

-   Passage complet au MVVM\
-   Recherche avancée\
-   Export PDF / Excel\
-   Gestion des emprunts
