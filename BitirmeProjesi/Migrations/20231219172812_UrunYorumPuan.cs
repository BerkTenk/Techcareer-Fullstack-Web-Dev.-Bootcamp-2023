using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class UrunYorumPuan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Puan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PuanDegeri = table.Column<int>(type: "INTEGER", nullable: false),
                    UrunId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puan_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciAdi = table.Column<string>(type: "TEXT", nullable: true),
                    YorumMetni = table.Column<string>(type: "TEXT", nullable: true),
                    UrunId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorum_Urunler_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunler",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puan_UrunId",
                table: "Puan",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_UrunId",
                table: "Yorum",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puan");

            migrationBuilder.DropTable(
                name: "Yorum");
        }
    }
}
