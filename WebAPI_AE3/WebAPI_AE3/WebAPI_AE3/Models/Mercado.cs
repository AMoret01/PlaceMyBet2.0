using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class Mercado
    {
        public int MercadoId { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public double TipoMercado { get; set; }
        public List<Apuesta> Apuestas { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public Mercado(int idMercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, double tipoMercado, int EventoId)
        {
            MercadoId = idMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            TipoMercado = tipoMercado;
            this.EventoId = EventoId;
        }
        public Mercado() { }
    }

    public class MercadoDTO
    {
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double tipoMercado { get; set; }

        public MercadoDTO(double cuotaOver, double cuotaUnder, double tipoMercado)
        {
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.tipoMercado = tipoMercado;
        }
    }
}