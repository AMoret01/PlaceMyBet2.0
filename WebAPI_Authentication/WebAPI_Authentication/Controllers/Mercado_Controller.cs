using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Route("api/Mercado/{action}")]
    public class Mercado_Controller : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Mercado> Get()
        {
            Repositorio_Mercado repository = new Repositorio_Mercado();
            List<Mercado> mercados = repository.retrieve();
            return mercados;
        }
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<MercadoDTO> GetDTO()
        {
            var repository = new Repositorio_Mercado();
            List<MercadoDTO> mercados = repository.retrieveDTO();
            return mercados;
        }

        [HttpGet]
        public IEnumerable<Mercado> GetEvento(int id_Evento,double tipo_Mercado)
        {
            var repo = new Repositorio_Mercado();
            List<Mercado> mercados = repo.GetEvento(id_Evento,tipo_Mercado);
            return mercados;
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
