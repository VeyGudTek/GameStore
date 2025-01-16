using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "fighting" },
                    { 2, "sports" },
                    { 3, "adventure" },
                    { 4, "shooter" },
                    { 5, "racing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
