using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

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
        internal void Save(Apuestas ap)
        {
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "INSERT INTO apuestas (`Id`, `email`, `over/under`,`Tipo`, `Dinero`) values ('" + ap.Id + "','" + ap.Email + "','" + ap.Over_under + "','" + ap.Tipo + "','" + ap.Dinero + "');";
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                conectar.Open();
                command.ExecuteNonQuery();
                conectar.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }

        }

    }
}