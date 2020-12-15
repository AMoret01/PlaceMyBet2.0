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
        public int EventoId { get; set; }




        public Apuesta(int idApuesta, string tipo, double cuota, double dinero, string fecha, int idMercado, string gmail, int eventoId)
        {
            ApuestaId = idApuesta;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
            this.fecha = fecha;
            MercadoId = idMercado;
            UsuarioId = gmail;
            EventoId = eventoId;
        }
        public Apuesta() { }
    }
    public class ApuestasDTO
    {
        public string Usuarioid { get; set; }
        public int EventoId { get; set; }
        public string tipoApuesta { get; set; }
        public double cuota { get; set; }
        public double dineroApuesta { get; set; }
        public Mercado Mercado { get; set; }

        public ApuestasDTO(string usuarioid, int eventoId, string tipoApuesta, double cuota, double dineroApuesta, Mercado mercado)
        {
            Usuarioid = usuarioid;
            EventoId = eventoId;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApuesta = dineroApuesta;
            Mercado = mercado;
        }

        public ApuestasDTO()
        {
        }
    }
}