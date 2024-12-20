using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArticleCatept2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppArticles_AppArticleCate_IdCategory",
                table: "AppArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppArticleCate",
                table: "AppArticleCate");

            migrationBuilder.RenameTable(
                name: "AppArticleCate",
                newName: "AppArticlesCates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppArticlesCates",
                table: "AppArticlesCates",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$10$lDw10IkXIiXGHSbQg/W6auep95c7zneRF5W6azNF8jXxuMHylNs1.");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$10$lDw10IkXIiXGHSbQg/W6auep95c7zneRF5W6azNF8jXxuMHylNs1.");

            migrationBuilder.AddForeignKey(
                name: "FK_AppArticles_AppArticlesCates_IdCategory",
                table: "AppArticles",
                column: "IdCategory",
                principalTable: "AppArticlesCates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppArticles_AppArticlesCates_IdCategory",
                table: "AppArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppArticlesCates",
                table: "AppArticlesCates");

            migrationBuilder.RenameTable(
                name: "AppArticlesCates",
                newName: "AppArticleCate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppArticleCate",
                table: "AppArticleCate",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$10$gm/PU9KvJHyPr2AsM2WMqOjap1QcsBwNDJXNCzVWcQyivr.AMADIK");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$10$gm/PU9KvJHyPr2AsM2WMqOjap1QcsBwNDJXNCzVWcQyivr.AMADIK");

            migrationBuilder.AddForeignKey(
                name: "FK_AppArticles_AppArticleCate_IdCategory",
                table: "AppArticles",
                column: "IdCategory",
                principalTable: "AppArticleCate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
