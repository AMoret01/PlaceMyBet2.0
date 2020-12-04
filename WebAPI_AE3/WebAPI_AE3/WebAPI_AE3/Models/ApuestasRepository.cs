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
            /*
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT * FROM apuesta";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Apuesta> apuesta = new List<Apuesta>();

                while (reader.Read())
                {
                    Apuesta e = new Apuesta(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetString(7));
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
            List<Apuesta> Apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Apuestas = context.Apuestas.ToList();
            }
            return Apuestas;
        }
        //Tanto para over como para under lo que tengo en el chat
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

                    mercado.CuotaOver = (1 / prob_over)*0.95;
                    mercado.CuotaUnder = (1 / prob_under)*0.95;

                    context.Mercados.Update(mercado);
                    context.Apuestas.Add(ap);
                    context.SaveChanges();

                }

           

            

        }

        internal List<ApuestaDTO> retrieveDTO()
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
            return null;
        }

    }
}