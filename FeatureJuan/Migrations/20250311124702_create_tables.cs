using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FeatureJuan.Migrations
{
    /// <inheritdoc />
    public partial class create_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisoes",
                columns: table => new
                {
                    DivisaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisoes", x => x.DivisaoId);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeIntegrantes = table.Column<int>(type: "int", nullable: false),
                    DivisaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeId);
                    table.ForeignKey(
                        name: "FK_Equipes_Divisoes_DivisaoId",
                        column: x => x.DivisaoId,
                        principalTable: "Divisoes",
                        principalColumn: "DivisaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Divisoes",
                columns: new[] { "DivisaoId", "Nome" },
                values: new object[,]
                {
                    { 1, "Brasileirão Série A" },
                    { 2, "Brasileirão Série B" },
                    { 3, "La Liga" },
                    { 4, "Premier League" },
                    { 5, "Ligue 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_DivisaoId",
                table: "Equipes",
                column: "DivisaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Divisoes");
        }
    }
}
