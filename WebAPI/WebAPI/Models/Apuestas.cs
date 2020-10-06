using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Apuestas
    {
        public Apuestas(int id, string email, double over_under, string tipo, int dinero)
        {
            Id = id;
            Email = email;
            Over_under = over_under;
            Tipo = tipo;
            Dinero = dinero;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public double Over_under { get; set; }
        public string Tipo { get; set; }
        public int Dinero { get; set; }



    }
}