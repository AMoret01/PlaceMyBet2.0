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
    
    public class EventosController : ApiController
    {
        // GET: api/Evento
        
        public IEnumerable<Evento> Get()
        {
            EventosRepository repository = new EventosRepository();
            List<Evento> eventos = repository.retrieve();
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

        //Poner frombody... en vez de tres datos
        // PUT: api/Evento/5
        public void Put(int id, string Local, string Visitante)
        {
            EventosRepository repo = new EventosRepository();
            repo.Put(id,Local, Visitante);
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
            EventosRepository repo = new EventosRepository();
            repo.Delete(id);
        }
    }
}
