using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Mercado
    {
        public Mercado(double over_under, double cuota_over, double cuota_under, double dineo_over, double dinero_under, int id_evento)
        {
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dineo_over = dineo_over;
            Dinero_under = dinero_under;
            Id_evento = id_evento;
        }

        public double Over_under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public double Dineo_over { get; set; }
        public double Dinero_under { get; set; }
        public int Id_evento { get; set; }

    }
    public class MercadoDTO
    {
        public MercadoDTO(double over_under, double cuota_over, double cuota_under)
        {
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            
        }

        public double Over_under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        

    }
}