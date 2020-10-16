using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class Repositorio_Mercado
    {
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }

        internal List<Mercado> retrieve()
        {
            MySqlConnection connection = conexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM mercado";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Mercado> mercado = new List<Mercado>();

                while (reader.Read())
                {
                    Mercado e = new Mercado(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetInt32(5));
                    mercado.Add(e);

                }
                connection.Close();
                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectarse con la base de datos ");
                return null;
            }
        }
        internal List<MercadoDTO> retrieveDTO()
        {
            MySqlConnection connection = conexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT `over/under`,`cuota over`,`cuota under` FROM mercado";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<MercadoDTO> mercado = new List<MercadoDTO>();

                while (reader.Read())
                {
                    MercadoDTO e = new MercadoDTO(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2));
                    mercado.Add(e);

                }
                connection.Close();
                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectarse con la base de datos ");
                return null;
            }
        }
    }
}