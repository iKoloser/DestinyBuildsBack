using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DestinyBuildsBack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmadurasExoticas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmadurasExoticas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmadurasExoticas_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subclases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subclases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subclases_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaseId = table.Column<int>(type: "int", nullable: false),
                    SubclaseId = table.Column<int>(type: "int", nullable: false),
                    ArmaPrincipalId = table.Column<int>(type: "int", nullable: false),
                    ArmaSecundariaId = table.Column<int>(type: "int", nullable: false),
                    ArmaTerciariaId = table.Column<int>(type: "int", nullable: false),
                    ArmaduraExoticaId = table.Column<int>(type: "int", nullable: false),
                    Mods = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Builds_ArmadurasExoticas_ArmaduraExoticaId",
                        column: x => x.ArmaduraExoticaId,
                        principalTable: "ArmadurasExoticas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Armas_ArmaPrincipalId",
                        column: x => x.ArmaPrincipalId,
                        principalTable: "Armas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Armas_ArmaSecundariaId",
                        column: x => x.ArmaSecundariaId,
                        principalTable: "Armas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Armas_ArmaTerciariaId",
                        column: x => x.ArmaTerciariaId,
                        principalTable: "Armas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Subclases_SubclaseId",
                        column: x => x.SubclaseId,
                        principalTable: "Subclases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmadurasExoticas_ClaseId",
                table: "ArmadurasExoticas",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_ArmaduraExoticaId",
                table: "Builds",
                column: "ArmaduraExoticaId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_ArmaPrincipalId",
                table: "Builds",
                column: "ArmaPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_ArmaSecundariaId",
                table: "Builds",
                column: "ArmaSecundariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_ArmaTerciariaId",
                table: "Builds",
                column: "ArmaTerciariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_ClaseId",
                table: "Builds",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_SubclaseId",
                table: "Builds",
                column: "SubclaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subclases_ClaseId",
                table: "Subclases",
                column: "ClaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Builds");

            migrationBuilder.DropTable(
                name: "ArmadurasExoticas");

            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Subclases");

            migrationBuilder.DropTable(
                name: "Clases");
        }
    }
}
