using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Route("api/Mercados/{action}")]
    public class MercadosController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Mercado> Get()
        {
            Repositorio_Mercado rep = new Repositorio_Mercado();
            List<Mercado> lista = rep.retrieve();
            return lista;
        }
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<MercadoDTO> GetDTO()
        {
            Repositorio_Mercado rep = new Repositorio_Mercado();
            List<MercadoDTO> lista = rep.retrieveDTO();
            return lista;
        }


        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mercados
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
