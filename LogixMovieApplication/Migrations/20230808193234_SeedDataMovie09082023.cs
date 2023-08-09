using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Logix_Movie_Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMovie09082023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "8Vt6mWEReuy4Of61Lnj5Xj704m8.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "bRdR9EMEjDr5jxMRyt7fvGF0Hy2.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 4, "yhx6PnU3L2a6FnEFGOlBKTZ8TSD.jpg", "Only Murders in the Building" },
                    { 5, "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg", "Squid Game" },
                    { 6, "reEMJA1uzscCbkpeRJeTT2bjqUp.jpg", "Money Heist" },
                    { 7, "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg", "3 Idiots" },
                    { 8, "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg", "Game of Thrones" },
                    { 9, "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg", "Avatar" },
                    { 10, "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg", "Vikings" },
                    { 11, "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg", "Game of Thrones" },
                    { 12, "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg", "Breaking Bad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8Vt6mWEReuy4Of61Lnj5Xj704m8.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/bRdR9EMEjDr5jxMRyt7fvGF0Hy2.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg");
        }
    }
}
