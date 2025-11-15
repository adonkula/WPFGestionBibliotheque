using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sommatif2GestionBibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class AjoutData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "Id", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, "Hugo", "Victor" },
                    { 2, "Zola", "Émile" },
                    { 3, "Dumas", "Alexandre" },
                    { 4, "La Fontaine", "Jean" },
                    { 5, "Munroe", "Myles" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Roman" },
                    { 2, "Classique" },
                    { 3, "Fantastique" },
                    { 4, "Histoire" }
                });

            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "AuteurId", "DatePublication", "Titre" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 1" },
                    { 2, 1, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 2" },
                    { 3, 3, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 3" },
                    { 4, 5, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 4" },
                    { 5, 2, new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 5" },
                    { 6, 4, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 6" },
                    { 7, 1, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 7" },
                    { 8, 1, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 8" },
                    { 9, 4, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 9" },
                    { 10, 2, new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 10" },
                    { 11, 4, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 11" },
                    { 12, 2, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 12" },
                    { 13, 5, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 13" },
                    { 14, 5, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 14" },
                    { 15, 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 15" },
                    { 16, 3, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 16" },
                    { 17, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 17" },
                    { 18, 4, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 18" },
                    { 19, 2, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 19" },
                    { 20, 1, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 20" },
                    { 21, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 21" },
                    { 22, 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 22" },
                    { 23, 3, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 23" },
                    { 24, 1, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 24" },
                    { 25, 4, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 25" },
                    { 26, 2, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 26" },
                    { 27, 5, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 27" },
                    { 28, 4, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 28" },
                    { 29, 1, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 29" },
                    { 30, 3, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Livre Test 30" }
                });

            migrationBuilder.InsertData(
                table: "DetailsLivres",
                columns: new[] { "Id", "ISBN", "LivreId", "NombrePages" },
                values: new object[,]
                {
                    { 1, "ISBN-1001", 1, 101 },
                    { 2, "ISBN-1002", 2, 102 },
                    { 3, "ISBN-1003", 3, 103 },
                    { 4, "ISBN-1004", 4, 104 },
                    { 5, "ISBN-1005", 5, 105 },
                    { 6, "ISBN-1006", 6, 106 },
                    { 7, "ISBN-1007", 7, 107 },
                    { 8, "ISBN-1008", 8, 108 },
                    { 9, "ISBN-1009", 9, 109 },
                    { 10, "ISBN-1010", 10, 110 },
                    { 11, "ISBN-1011", 11, 111 },
                    { 12, "ISBN-1012", 12, 112 },
                    { 13, "ISBN-1013", 13, 113 },
                    { 14, "ISBN-1014", 14, 114 },
                    { 15, "ISBN-1015", 15, 115 },
                    { 16, "ISBN-1016", 16, 116 },
                    { 17, "ISBN-1017", 17, 117 },
                    { 18, "ISBN-1018", 18, 118 },
                    { 19, "ISBN-1019", 19, 119 },
                    { 20, "ISBN-1020", 20, 120 },
                    { 21, "ISBN-1021", 21, 121 },
                    { 22, "ISBN-1022", 22, 122 },
                    { 23, "ISBN-1023", 23, 123 },
                    { 24, "ISBN-1024", 24, 124 },
                    { 25, "ISBN-1025", 25, 125 },
                    { 26, "ISBN-1026", 26, 126 },
                    { 27, "ISBN-1027", 27, 127 },
                    { 28, "ISBN-1028", 28, 128 },
                    { 29, "ISBN-1029", 29, 129 },
                    { 30, "ISBN-1030", 30, 130 }
                });

            migrationBuilder.InsertData(
                table: "LivreCategories",
                columns: new[] { "CategorieId", "LivreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 3, 4 },
                    { 1, 5 },
                    { 4, 5 },
                    { 3, 6 },
                    { 4, 6 },
                    { 3, 7 },
                    { 4, 7 },
                    { 4, 8 },
                    { 3, 9 },
                    { 4, 9 },
                    { 3, 10 },
                    { 4, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 4, 12 },
                    { 1, 13 },
                    { 3, 13 },
                    { 2, 14 },
                    { 4, 14 },
                    { 2, 15 },
                    { 1, 16 },
                    { 2, 16 },
                    { 3, 17 },
                    { 4, 17 },
                    { 4, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 3, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 3, 22 },
                    { 2, 23 },
                    { 1, 24 },
                    { 3, 24 },
                    { 3, 25 },
                    { 4, 25 },
                    { 1, 26 },
                    { 4, 26 },
                    { 1, 27 },
                    { 3, 27 },
                    { 1, 28 },
                    { 4, 28 },
                    { 4, 29 },
                    { 1, 30 },
                    { 2, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DetailsLivres",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 20 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 24 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 25 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 26 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 26 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 3, 27 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 28 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 28 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 4, 29 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 1, 30 });

            migrationBuilder.DeleteData(
                table: "LivreCategories",
                keyColumns: new[] { "CategorieId", "LivreId" },
                keyValues: new object[] { 2, 30 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Auteurs",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
