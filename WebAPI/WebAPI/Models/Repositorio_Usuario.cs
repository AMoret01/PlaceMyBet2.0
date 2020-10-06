using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebAPI.Models
{
    public class Repositorio_Usuario
    {
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }

        internal List<Usuario> retrieve()
        {
            MySqlConnection connection = conexion();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM usuario";

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Usuario> usuario = new List<Usuario>();

                while (reader.Read())
                {
                    Usuario e = new Usuario(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                    usuario.Add(e);

                }
                connection.Close();
                return usuario;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectarse con la base de datos ");
                return null;
            }
        }
    }
}