using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppContact",
                table: "AppContact");

            migrationBuilder.RenameTable(
                name: "AppContact",
                newName: "AppContacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppContacts",
                table: "AppContacts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$10$e6oaR/la1dMlaICmCWjq/eCqa8JmBdgxr848OiftVzEYEdJZtSi3a");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$10$e6oaR/la1dMlaICmCWjq/eCqa8JmBdgxr848OiftVzEYEdJZtSi3a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppContacts",
                table: "AppContacts");

            migrationBuilder.RenameTable(
                name: "AppContacts",
                newName: "AppContact");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppContact",
                table: "AppContact",
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
        }
    }
}
