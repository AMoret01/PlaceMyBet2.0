using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
        public string fecha { get; set; }
        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string EventoId { get; set; }
        public Evento Evento { get; set; }



        public Apuesta(int idApuesta, string tipo, double cuota, double dinero, string fecha, int idMercado, string gmail)
        {
            ApuestaId = idApuesta;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
            this.fecha = fecha;
            MercadoId = idMercado;
            UsuarioId = gmail;
        }
        public Apuesta() { }
    }
    public class ApuestasDTO
    {
        private int eventoId;

        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
        public string fecha { get; set; }
        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public ApuestasDTO(string usuarioId, string tipo, double cuota, double dinero, int eventoId, Mercado mercado)
        {
            UsuarioId = usuarioId;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
            this.EventoId = eventoId;
            Mercado = mercado;
        }
    }
}