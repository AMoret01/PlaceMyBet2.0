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
    [Route("api/Evento/{action}")]
    public class EventoController : ApiController
    {
        // GET: api/Evento
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Evento> Get()
        {
            EventosRepository repository = new EventosRepository();
            List<Evento> eventos = repository.retrieve();
            return eventos;
        }
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<EventoDTO> GetDTO()
        {
            var repository = new EventosRepository();
            List<EventoDTO> eventos = repository.retrieveDTO();
            return eventos;
        }

        // GET: api/Evento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Evento
        public void Post([FromBody] Evento eventos)
        {
            var repo = new EventosRepository();
            repo.Save(eventos);
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
