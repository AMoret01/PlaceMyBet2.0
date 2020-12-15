using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using WebAPI_AE3.Models;

namespace WebAPI_AE3.Controllers
{
    public class CuentasController : ApiController
    {
        // GET: api/Cuenta
        public IEnumerable<Cuenta> Get()
        {
            var repo = new CuentaRepository();
            List<Cuenta> cuentas = repo.retrieve();
            return cuentas;
        }

        // GET: api/Cuenta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cuenta
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/Cuenta/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Cuenta/5
        public void Delete(int id)
        {
        }
    }
}
