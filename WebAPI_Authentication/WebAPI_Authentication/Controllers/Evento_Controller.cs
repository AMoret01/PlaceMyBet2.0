using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Evento/{action}")]
    public class Evento_Controller : ApiController
    {
        // GET: api/Evento
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Evento> Get()
        {
            Repositorio_Evento repository = new Repositorio_Evento();
            List<Evento> eventos = repository.retrieve();
            return eventos;
        }
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<EventoDTO> GetDTO()
        {
            var repository = new Repositorio_Evento();
            List<EventoDTO> eventos = repository.retrieveDTO();
            return eventos;
        }

        // GET: api/Evento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Evento
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Evento/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
        }
    }
}
