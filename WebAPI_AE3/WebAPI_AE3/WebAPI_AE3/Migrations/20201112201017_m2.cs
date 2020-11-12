using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_AE3.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "Fecha", "Local", "Visitante" },
                values: new object[,]
                {
                    { 1, "2020-07-20", "Madrid", "Betis" },
                    { 2, "2020-04-19", "Valencia", "PSG" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellido", "Edad", "Nombre" },
                values: new object[,]
                {
                    { "Carla@gmail.com", "Arbiol", 30, "Carla" },
                    { "Irene@gmail.com", "Gomez", 12, "Irene" }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "CuotaOver", "CuotaUnder", "DineroOver", "DineroUnder", "EventoId", "TipoMercado" },
                values: new object[] { 1, 1.5, 7.0999999999999996, 250.0, 100.0, 1, 2.5 });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoId", "CuotaOver", "CuotaUnder", "DineroOver", "DineroUnder", "EventoId", "TipoMercado" },
                values: new object[] { 2, 2.2999999999999998, 1.6000000000000001, 150.0, 50.0, 1, 1.5 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "MercadoId", "UsuarioId", "cuota", "dinero", "fecha", "tipoCuota", "tipoMercado" },
                values: new object[] { 1, 1, "Carla@gmail.com", 1.75, 125.0, "2020-03-13", "over", 2.1000000000000001 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaId", "MercadoId", "UsuarioId", "cuota", "dinero", "fecha", "tipoCuota", "tipoMercado" },
                values: new object[] { 2, 2, "Irene@gmail.com", 1.1000000000000001, 100.0, "2020-04-14", "under", 3.2999999999999998 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apuestas",
                keyColumn: "ApuestaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mercados",
                keyColumn: "MercadoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "Carla@gmail.com");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: "Irene@gmail.com");

            migrationBuilder.DeleteData(
                table: "Eventos",
                keyColumn: "EventoId",
                keyValue: 1);
        }
    }
}
