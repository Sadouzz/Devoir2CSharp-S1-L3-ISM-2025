using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GesCompte.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "comptes",
                columns: new[] { "Id", "DateCreation", "DateDeblocage", "Numero", "Solde", "Statut", "Titulaire", "Type" },
                values: new object[,]
                {
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SN001", 510500m, "Actif", "Ousman Sadjo", "Epargne" },
                    { 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "SN002", 50500m, "Actif", "Layla Sadjo", "Courant" }
                });

            migrationBuilder.InsertData(
                table: "transactions",
                columns: new[] { "Id", "Code", "CompteId", "Date", "Description", "Montant", "SoldeApres", "Type" },
                values: new object[,]
                {
                    { 1, "TRX001", 1, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dépôt cash au guichet", 150000m, 150000m, "Depot" },
                    { 2, "TRX002", 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dépôt cash", 50000m, 200000m, "Depot" },
                    { 3, "TRX003", 1, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salaire mensuel", 120000m, 320000m, "Depot" },
                    { 4, "TRX004", 1, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retrait ATM Dakar Plateau", -20000m, 300000m, "Retrait" },
                    { 5, "TRX005", 1, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Achat Orange Money", -15000m, 285000m, "Retrait" },
                    { 6, "TRX006", 1, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dépôt wave", 30000m, 315000m, "Depot" },
                    { 7, "TRX007", 1, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paiement Freelance", 80000m, 395000m, "Depot" },
                    { 8, "TRX008", 1, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Achat nourriture Auchan", -25000m, 370000m, "Retrait" },
                    { 9, "TRX009", 1, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Café Matin", -5000m, 365000m, "Retrait" },
                    { 10, "TRX010", 1, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transport Dem Dikk", -10000m, 355000m, "Retrait" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "comptes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "comptes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
