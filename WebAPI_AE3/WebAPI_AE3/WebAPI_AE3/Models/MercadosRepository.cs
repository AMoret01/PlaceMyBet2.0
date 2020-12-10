using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
namespace WebAPI_AE3.Models
{
    public class MercadosRepository
    {
        /*
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }
        */

        internal List<Mercado> retrieve()
        {
            /*
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT * FROM mercado";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Mercado> mercado = new List<Mercado>();

                while (reader.Read())
                {
                    Mercado e = new Mercado(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetInt32(6));
                    mercado.Add(e);

                }
                conectar.Close();
                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }*/
            List<Mercado> Mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Mercados = context.Mercados.ToList();
            }
            return Mercados;
        }
        internal Mercado Retrieve(int id)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(m => m.MercadoId == id)
                    .FirstOrDefault();
            }

            return mercado;
        }

        internal List<MercadoDTO> retrieveDTO()
        {
            /*
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT tipo_Mercado,cuota_Over,cuota_Under FROM mercado";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<MercadoDTO> mercado = new List<MercadoDTO>();

                while (reader.Read())
                {
                    MercadoDTO e = new MercadoDTO(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2));
                    mercado.Add(e);

                }
                conectar.Close();
                return mercado;
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