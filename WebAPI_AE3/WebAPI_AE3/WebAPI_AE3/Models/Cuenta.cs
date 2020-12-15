using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_AE3.Models
{
    public class Cuenta
    {
        public double saldo { get; set; }
        public string nombreBanco { get; set; }
        public string CuentaId { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cuenta(double saldo, string nombreBanco, string cuentaId, string usuarioId)
        {
            this.saldo = saldo;
            this.nombreBanco = nombreBanco;
            CuentaId = cuentaId;
            UsuarioId = usuarioId;
        }

        public Cuenta()
        {
        }
    }
}