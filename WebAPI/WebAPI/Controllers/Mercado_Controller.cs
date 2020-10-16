using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Mercado_Controller : ApiController
    {
        // GET: api/Mercado_
        public IEnumerable<MercadoDTO> Get()
        {
            var repositorio = new Repositorio_Mercado();
            List<MercadoDTO> mercados = repositorio.retrieveDTO();
            return mercados;
        }

        // GET: api/Mercado_/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mercado_
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado_/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado_/5
        public void Delete(int id)
        {
        }
    }
}
