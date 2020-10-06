using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Evento
    {
        public Evento(string local, string visitante, string fecha, int id_evento)
        {
            Local = local;
            Visitante = visitante;
            Fecha = fecha;
            Id_evento = id_evento;
        }

        public string Local { get; set; }
        public string Visitante { get; set; }
        public string Fecha { get; set; }
        public  int Id_evento { get; set; }

    }

    
}