using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class Repositorio_Evento
    {
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }

        internal List<Evento> retrieve()
        {
            MySqlConnection connection = conexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM evento";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Evento> evento = new List<Evento>();

                while (reader.Read())
                {
                    Evento e = new Evento(reader.GetString(0), reader.GetString(1), reader.GetMySqlDateTime(2).ToString(), reader.GetInt32(3));
                    evento.Add(e);

                }
                connection.Close();
                return evento;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectarse con la base de datos ");
                return null;
            }
        }
        internal List<EventoDTO> retrieveDTO()
        {
            MySqlConnection connection = conexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT local,visitante,fecha FROM evento";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<EventoDTO> evento = new List<EventoDTO>();

                while (reader.Read())
                {
                    EventoDTO e = new EventoDTO(reader.GetString(0), reader.GetString(1), reader.GetMySqlDateTime(2).ToString());
                    evento.Add(e);

                }
                connection.Close();
                return evento;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectarse con la base de datos ");
                return null;
            }
        }
    }
}