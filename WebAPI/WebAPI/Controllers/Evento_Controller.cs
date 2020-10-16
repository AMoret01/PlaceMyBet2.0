using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Evento_Controller : ApiController
    {
        // GET: api/Evento_
        public IEnumerable<EventoDTO> Get()
        {
            var repositorio = new Repositorio_Evento();
            List<EventoDTO> eventos = repositorio.retrieveDTO();
            return eventos;
        }

        // GET: api/Evento_/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Evento_
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Evento_/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Evento_/5
        public void Delete(int id)
        {
        }
    }
}
