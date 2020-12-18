using Microsoft.EntityFrameworkCore;
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
        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(e);
            context.SaveChanges();
        }
        internal Evento retrieveId(int id)
        {
            using (var context = new PlaceMyBetContext())
            {
                var evento = context.Eventos
                    .FirstOrDefault(b => b.EventoId == id);
                return evento;
            }
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
        internal void Put(int id, string Local, string Visitante)
        {
            Evento evento;
            PlaceMyBetContext context = new PlaceMyBetContext();
            evento = context.Eventos.FirstOrDefault(e => e.EventoId == id);

            evento.Local = Local;
            evento.Visitante = Visitante;

            context.SaveChanges();
        }
        internal void Delete(int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Evento e;
            using (context)
            {
                e = context.Eventos.Single(b => b.EventoId == id);
                context.Eventos.Remove(e);
                context.SaveChanges();
            }
        }
        static public EventoDTO ToDTO(Evento e)
        {
            return new EventoDTO(e.Local, e.Visitante);

        }
        static public Eventos2 ToDTOEx(Evento e, string equipo)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Mercado m;
            using (context)
            {
                m = context.Mercados.FirstOrDefault(b => b.EventoId == e.EventoId);
            }
            if (e.Local == equipo)
            {
                return new Eventos2(e.Visitante, m.MercadoId, m.CuotaOver, m.CuotaUnder);
            }
            else
            {
                return new Eventos2(e.Local, m.MercadoId, m.CuotaOver, m.CuotaUnder);
            }
        }
        //Ejercicio 1
        internal List<Eventos2> retrieveRival(string rival)
        {
            List<Evento> evento;
            List<Eventos2> rivalfinal = new List<Eventos2>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Where(a => a.Local == rival || a.Visitante == rival).ToList();
            }
            for (int i = 0; i < evento.Count; i++)
            {
                rivalfinal.Add(ToDTOEx(evento[i], rival));
            }
            return rivalfinal;
        }

    }
}