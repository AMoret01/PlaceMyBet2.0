using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Repositorio_Apuestas
    {
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }

        internal List<Apuestas> retrieve()
        {
            MySqlConnection connection = conexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM apuestas";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Apuestas> apuestas = new List<Apuestas>();

                while (reader.Read())
                {
                    Apuestas e = new Apuestas(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3), reader.GetInt32(4));
                    apuestas.Add(e);

                }
                connection.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectarse con la base de datos ");
                return null;
            }
        }
        internal List<ApuestasDTO> retrieveDTO()
        {
            MySqlConnection connection = conexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT apuestas.`email`,apuestas.`over/under`,apuestas.`Dinero`,apuestas.`Tipo`,mercado.`cuota over`,mercado.`cuota under`,evento.`Fecha` FROM apuestas INNER JOIN mercado ON apuestas.`over/under` = mercado.`over/under` INNER JOIN evento ON mercado.`Id evento` = evento.`Id evento`;";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<ApuestasDTO> apuestas = new List<ApuestasDTO>();

                while (reader.Read())
                {
                    ApuestasDTO e = new ApuestasDTO(reader.GetString(0), reader.GetDouble(1), reader.GetString(2), reader.GetString(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetString(6));
                    apuestas.Add(e);

                }
                connection.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectarse con la base de datos ");
                return null;
            }
        }
        internal void Save(Apuestas a)
        {
            MySqlConnection con = conexion();
            MySqlCommand command = con.CreateCommand();
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            command.CommandText = "select * from mercado where `Id evento`=" + a.Id + ";";
            
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                res.Read();
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDouble(2) + " " + res.GetString(3) + " " + res.GetDouble(4));
                Mercado m = new Mercado(res.GetDouble(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetInt32(5));



                double dineroOver = 0;
                double dineroUnder = 0;
                if (a.Tipo == "over")
                {
                    dineroOver = a.Dinero + m.Dinero_over;
                    dineroUnder = m.Dinero_under;
                }
                else
                {
                    dineroOver = m.Dinero_over;
                    dineroUnder = a.Dinero + m.Dinero_under;
                }

                double cuotaOver = dineroOver / (dineroOver + dineroUnder);
                cuotaOver = (1 / cuotaOver) * 0.95;
                double cuotaUnder = dineroUnder / (dineroUnder + dineroOver);
                cuotaUnder = (1 / cuotaUnder) * 0.95;
                res.Close();
                con.Close();
                command.CommandText = "update mercado set `cuota over`=" + Math.Round(cuotaOver, 2) + ", `cuota under`=" + Math.Round(cuotaUnder, 2) + ", `dinero over`=" + dineroOver + ", `dinero under`=" + dineroUnder + " where `id evento`=" + a.Id + ";";
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    double cuotaApuesta = 0;
                    if (a.Tipo == "under")
                    {
                        cuotaApuesta = cuotaUnder;
                    }
                    else
                    {
                        cuotaApuesta = cuotaOver;
                    }
                    command.CommandText = "insert into apuestas (tipoMercado, cuota, dinero, fecha, idMercado, gmail, tipoCuota) values (" + a.Tipo + ", " + Math.Round(cuotaApuesta, 2) + ", " + a.Dinero + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + a.Id + ", '" + a.Email + "', '" + a.Tipo + "');";
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (MySqlException e)
                    {
                        Debug.WriteLine("Se ha producido un error de conexion");
                    }
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Se ha producido un error de conexion");
                }

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
            }


        }

    }
}