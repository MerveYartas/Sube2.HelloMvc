using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class tblProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ogrenciler",
                table: "Ogrenciler");

            migrationBuilder.RenameTable(
                name: "Ogrenciler",
                newName: "tblOgrenciler");

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "tblOgrenciler",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "tblOgrenciler",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOgrenciler",
                table: "tblOgrenciler",
                column: "Ogrenciid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOgrenciler",
                table: "tblOgrenciler");

            migrationBuilder.RenameTable(
                name: "tblOgrenciler",
                newName: "Ogrenciler");

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Ogrenciler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ogrenciler",
                table: "Ogrenciler",
                column: "Ogrenciid");
        }
    }
}
