using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public string Fecha { get; set; }
        public List<Mercado> Mercados { get; set; }

        public Evento(int idEvento, string local, string visitante, string fecha)
        {
            this.EventoId = idEvento;
            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
        }
        public Evento() { }
    }

    public class EventoDTO
    {
        public string local { get; set; }
        public string visitante { get; set; }

        public EventoDTO(string local, string visitante)
        {
            this.local = local;
            this.visitante = visitante;
        }
    }
    //Ejercicio 1
    public class Eventos2
    {
        public double CuotaOver { get; set; }
        public string Visitante { get; set; }
        public double CuotaUnder { get; set; }
        public int MercadoId { get; set; }

        public Eventos2(string rival, int idMercado, double cuotaOver, double cuotaUnder)
        {
            Visitante = rival;
            MercadoId = idMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
        }
    }
}