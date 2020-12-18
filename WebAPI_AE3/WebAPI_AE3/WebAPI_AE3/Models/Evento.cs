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
    public class EventosExamen
    {
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public string Fecha { get; set; }
        public Mercado Mercados { get; set; }

        public EventosExamen(int idEvento, string local, string visitante, string fecha,Mercado Mercados)
        {
            { 
                EventoId = idEvento;
                Local = local;
                Visitante = visitante;
                Fecha = fecha;
                this.Mercados = Mercados;
            }
        }

    }
}