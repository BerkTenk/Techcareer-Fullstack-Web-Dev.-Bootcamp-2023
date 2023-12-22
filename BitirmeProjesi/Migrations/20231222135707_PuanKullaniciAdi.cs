using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class PuanKullaniciAdi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "Puanlar",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "Puanlar");
        }
    }
}
