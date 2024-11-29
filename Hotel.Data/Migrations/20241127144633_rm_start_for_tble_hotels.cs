using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class rm_start_for_tble_hotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarRating",
                table: "AppHotel");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "AppRoomCates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "AppRoomCates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StarRating",
                table: "AppHotel",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$10$BuOf5dkS3bU249LX9AwHFObrA79PNUrwqjcHfUkhUp3cWw/gwWQQa");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$10$BuOf5dkS3bU249LX9AwHFObrA79PNUrwqjcHfUkhUp3cWw/gwWQQa");
        }
    }
}
