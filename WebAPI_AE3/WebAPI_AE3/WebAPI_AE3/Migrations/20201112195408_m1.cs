using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_AE3.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(nullable: true),
                    Visitante = table.Column<string>(nullable: true),
                    Fecha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CuotaOver = table.Column<double>(nullable: false),
                    CuotaUnder = table.Column<double>(nullable: false),
                    DineroOver = table.Column<double>(nullable: false),
                    DineroUnder = table.Column<double>(nullable: false),
                    TipoMercado = table.Column<double>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_Mercados_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    ApuestaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoMercado = table.Column<double>(nullable: false),
                    cuota = table.Column<double>(nullable: false),
                    dinero = table.Column<double>(nullable: false),
                    fecha = table.Column<string>(nullable: true),
                    tipoCuota = table.Column<string>(nullable: true),
                    MercadoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.ApuestaId);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercados",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_MercadoId",
                table: "Apuestas",
                column: "MercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_UsuarioId",
                table: "Apuestas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_EventoId",
                table: "Mercados",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
