using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_AE3.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoCuota",
                table: "Apuestas");

            migrationBuilder.DropColumn(
                name: "tipoMercado",
                table: "Apuestas");

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Apuestas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1,
                column: "tipo",
                value: "over");

            migrationBuilder.UpdateData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 2,
                column: "tipo",
                value: "under");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Apuestas");

            migrationBuilder.AddColumn<string>(
                name: "tipoCuota",
                table: "Apuestas",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "tipoMercado",
                table: "Apuestas",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1,
                columns: new[] { "tipoCuota", "tipoMercado" },
                values: new object[] { "over", 2.1000000000000001 });

            migrationBuilder.UpdateData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 2,
                columns: new[] { "tipoCuota", "tipoMercado" },
                values: new object[] { "under", 3.2999999999999998 });
        }
    }
}
