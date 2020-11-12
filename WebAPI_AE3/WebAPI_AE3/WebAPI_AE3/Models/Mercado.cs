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

        public Mercado(int idMercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, double tipoMercado, int idEvento)
        {
            this.MercadoId = idMercado;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
            this.DineroOver = dineroOver;
            this.DineroUnder = dineroUnder;
            this.TipoMercado = tipoMercado;
            this.EventoId = idEvento;
        }
        public Mercado() { }
    }

    public class MercadoDTO
    {
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public double tipoMercado { get; set; }

        public MercadoDTO(double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, double tipoMercado)
        {
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            this.tipoMercado = tipoMercado;
        }
    }
}