using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class SepetTablosu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Urunler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Urunler",
                type: "TEXT",
                nullable: true);
        }
    }
}
