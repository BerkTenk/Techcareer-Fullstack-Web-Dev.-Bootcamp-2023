using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitirmeProjesi.Migrations
{
    /// <inheritdoc />
    public partial class Yorumlar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puan_Urunler_UrunId",
                table: "Puan");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorum_Urunler_UrunId",
                table: "Yorum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yorum",
                table: "Yorum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puan",
                table: "Puan");

            migrationBuilder.RenameTable(
                name: "Yorum",
                newName: "Yorumlar");

            migrationBuilder.RenameTable(
                name: "Puan",
                newName: "Puanlar");

            migrationBuilder.RenameIndex(
                name: "IX_Yorum_UrunId",
                table: "Yorumlar",
                newName: "IX_Yorumlar_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_Puan_UrunId",
                table: "Puanlar",
                newName: "IX_Puanlar_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yorumlar",
                table: "Yorumlar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puanlar",
                table: "Puanlar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Puanlar_Urunler_UrunId",
                table: "Puanlar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorumlar_Urunler_UrunId",
                table: "Yorumlar",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puanlar_Urunler_UrunId",
                table: "Puanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Yorumlar_Urunler_UrunId",
                table: "Yorumlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yorumlar",
                table: "Yorumlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Puanlar",
                table: "Puanlar");

            migrationBuilder.RenameTable(
                name: "Yorumlar",
                newName: "Yorum");

            migrationBuilder.RenameTable(
                name: "Puanlar",
                newName: "Puan");

            migrationBuilder.RenameIndex(
                name: "IX_Yorumlar_UrunId",
                table: "Yorum",
                newName: "IX_Yorum_UrunId");

            migrationBuilder.RenameIndex(
                name: "IX_Puanlar_UrunId",
                table: "Puan",
                newName: "IX_Puan_UrunId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yorum",
                table: "Yorum",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Puan",
                table: "Puan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Puan_Urunler_UrunId",
                table: "Puan",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Yorum_Urunler_UrunId",
                table: "Yorum",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "UrunId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
