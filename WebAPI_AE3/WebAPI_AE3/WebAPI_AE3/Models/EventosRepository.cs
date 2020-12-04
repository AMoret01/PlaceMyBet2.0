using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class EventosRepository
    {
        /*
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }*/

        internal List<Evento> retrieve()
        {
            /*
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT * FROM evento";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Evento> evento = new List<Evento>();

                while (reader.Read())
                {
                    Evento e = new Evento(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetMySqlDateTime(3).ToString());
                    evento.Add(e);

                }
                conectar.Close();
                return evento;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }*/
            List<Evento> Eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Eventos = context.Eventos.ToList();
            }
            return Eventos;
        }

        internal List<EventoDTO> retrieveDTO()
        {
            /*
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT local,visitante,fecha FROM evento";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<EventoDTO> evento = new List<EventoDTO>();

                while (reader.Read())
                {
                    EventoDTO e = new EventoDTO(reader.GetString(0), reader.GetString(1), reader.GetMySqlDateTime(2).ToString());
                    evento.Add(e);

                }
                conectar.Close();
                return evento;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }*/
            return null;
        }
        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(e);
            context.SaveChanges();
        }
    }
}