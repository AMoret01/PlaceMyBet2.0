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
        public string fecha { get; set; }

        public EventoDTO(string local, string visitante, string fecha)
        {
            this.local = local;
            this.visitante = visitante;
            this.fecha = fecha;
        }
    }
}