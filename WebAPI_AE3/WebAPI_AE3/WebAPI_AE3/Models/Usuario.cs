using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Cuenta Cuenta { get; set; }
        public List<Apuesta> Apuestas { get; set; }

        public Usuario(string usuarioId, string nombre, string apellido, int edad)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }
        public Usuario() { }
    }
}