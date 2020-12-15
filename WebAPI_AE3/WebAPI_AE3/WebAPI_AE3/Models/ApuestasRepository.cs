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
    public class ApuestasRepository
    {
        /*
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;
        }
        */

        internal List<Apuesta> retrieve()
        {
            List<Apuesta> Apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Apuestas = context.Apuestas.Include(m => m.Mercado).ToList();
            }
            return Apuestas;

        }
        internal void Save(Apuesta ap)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                .Where(m => m.MercadoId == ap.MercadoId)
                .FirstOrDefault();

                if (ap.tipo == "over")
                {
                    mercado.DineroOver += ap.dinero;
                    ap.cuota = mercado.CuotaOver;
                }
                else
                {
                    mercado.DineroUnder += ap.dinero;
                    ap.cuota = mercado.CuotaUnder;
                }

                double prob_over = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);
                double prob_under = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);

                mercado.CuotaOver = (1 / prob_over) * 0.95;
                mercado.CuotaUnder = (1 / prob_under) * 0.95;

                context.Mercados.Update(mercado);
                context.Apuestas.Add(ap);
                context.SaveChanges();

            }
        }
        internal Apuesta retrieveId(int id)
        {
            using (var context = new PlaceMyBetContext())
            {
                var apuesta = context.Apuestas
                    .FirstOrDefault(a => a.ApuestaId == id);
                return apuesta;
            }
        }
        public static ApuestasDTO ToDTO(Apuesta a)
        {
            return new ApuestasDTO(a.UsuarioId, a.EventoId, a.tipo, a.cuota, a.dinero, a.Mercado);
        }

        internal List<ApuestasDTO> retrieveDTO()
        {
            /*
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT email,tipo_Mercado,cuota,tipo_Cuota,dinero,fecha FROM apuesta;";
            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<ApuestaDTO> apuesta = new List<ApuestaDTO>();
                while (reader.Read())
                {
                    ApuestaDTO e = new ApuestaDTO(reader.GetString(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetString(3), reader.GetDouble(4), reader.GetString(5));
                    apuesta.Add(e);
                }
                conectar.Close();
                return apuesta;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }*/

            List<ApuestasDTO> apuestasDTO = new List<ApuestasDTO>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestasDTO = context.Apuestas.Include(e => e.Mercado).Select(p => ToDTO(p)).ToList();
            }
            return apuestasDTO;

        }
    }
}