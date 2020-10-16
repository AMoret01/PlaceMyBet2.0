using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Eventos_/{action}")]
    public class EventosController : ApiController
    {

        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Evento> Get()
        {
            Repositorio_Evento rep = new Repositorio_Evento();
            List<Evento> lista = rep.retrieve();
            return lista;
        }

        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<EventoDTO> GetDTO()
        {
            Repositorio_Evento rep = new Repositorio_Evento();
            List<EventoDTO> lista = rep.retrieveDTO();
            return lista;
        }



        // GET: api/Eventos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Eventos
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
