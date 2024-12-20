using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArticleCate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AppArticles",
                newName: "Images");

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "AppArticles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppArticleCate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppArticleCate", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AppArticles_IdCategory",
                table: "AppArticles",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_AppArticles_AppArticleCate_IdCategory",
                table: "AppArticles",
                column: "IdCategory",
                principalTable: "AppArticleCate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppArticles_AppArticleCate_IdCategory",
                table: "AppArticles");

            migrationBuilder.DropTable(
                name: "AppArticleCate");

            migrationBuilder.DropIndex(
                name: "IX_AppArticles_IdCategory",
                table: "AppArticles");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "AppArticles");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "AppArticles",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$10$Eo58k2hSXsOVxH1N/Vwu/.964Pwh5IAlZCG8Z8jNLeEiIO7poLqkW");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$10$Eo58k2hSXsOVxH1N/Vwu/.964Pwh5IAlZCG8Z8jNLeEiIO7poLqkW");
        }
    }
}
