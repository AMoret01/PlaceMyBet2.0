using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Usuario
    {
        public Usuario(string nombre, string apellidos, int edad, string email)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Email = email;
        }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }


    }
}