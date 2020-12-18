using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_AE3.Models;

namespace WebAPI_AE3.Controllers
{
    public class EventosExamenController : ApiController
    {
        // GET: api/EventosExamen
        public IEnumerable<Eventos2> Get(string val)
        {
            EventosRepository repository = new EventosRepository();
            List<Eventos2> eventos = repository.retrieveRival(val);
            return eventos;
        }


        // POST: api/EventosExamen
        public void Post([FromBody] Evento evento, [FromBody] Mercado mercado)
        {
            EventosRepository repository2 = new EventosRepository();
            repository2.Save(evento);
            MercadosRepository repository = new MercadosRepository();
            repository.Save(mercado);
        }

        // PUT: api/EventosExamen/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/EventosExamen/5
        public void Delete(int id)
        {
        }
    }
}
