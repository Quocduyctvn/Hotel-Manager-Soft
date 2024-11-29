using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class ud_fk_tble_per : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRolePermissions_AppPermissions_IdPermission",
                table: "AppRolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_AppRolePermissions_IdPermission",
                table: "AppRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPermissions",
                table: "AppPermissions");

            migrationBuilder.AddColumn<int>(
                name: "IdGroup",
                table: "AppRolePermissions",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPermissions",
                table: "AppPermissions",
                columns: new[] { "PerCode", "IdGroup" });

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$10$WYPH5P7cYMFkqjTeQuLBSuuIiF7E0zWoqgzoZgRr8a89H4nZGo70m");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$10$WYPH5P7cYMFkqjTeQuLBSuuIiF7E0zWoqgzoZgRr8a89H4nZGo70m");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_IdPermission_IdGroup",
                table: "AppRolePermissions",
                columns: new[] { "IdPermission", "IdGroup" });

            migrationBuilder.AddForeignKey(
                name: "FK_AppRolePermissions_AppPermissions_IdPermission_IdGroup",
                table: "AppRolePermissions",
                columns: new[] { "IdPermission", "IdGroup" },
                principalTable: "AppPermissions",
                principalColumns: new[] { "PerCode", "IdGroup" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRolePermissions_AppPermissions_IdPermission_IdGroup",
                table: "AppRolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_AppRolePermissions_IdPermission_IdGroup",
                table: "AppRolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppPermissions",
                table: "AppPermissions");

            migrationBuilder.DropColumn(
                name: "IdGroup",
                table: "AppRolePermissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppPermissions",
                table: "AppPermissions",
                column: "PerCode");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$10$/si.vLvf6GuFq.e.OOtpTuVYJxIVtd0lBPsl5UHwvggJPssn9hzL.");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$10$/si.vLvf6GuFq.e.OOtpTuVYJxIVtd0lBPsl5UHwvggJPssn9hzL.");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermissions_IdPermission",
                table: "AppRolePermissions",
                column: "IdPermission");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRolePermissions_AppPermissions_IdPermission",
                table: "AppRolePermissions",
                column: "IdPermission",
                principalTable: "AppPermissions",
                principalColumn: "PerCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
