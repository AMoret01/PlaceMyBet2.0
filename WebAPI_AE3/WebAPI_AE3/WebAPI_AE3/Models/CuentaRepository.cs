using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class CuentaRepository
    {
        internal List<Cuenta> retrieve()
        {
            List<Cuenta> Cuentas = new List<Cuenta>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                Cuentas = context.Cuenta.ToList();
            }
            return Cuentas;
        }
    }
}