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
    
    public class MercadosController : ApiController
    {
        // GET: api/Mercado
        
        /*public IEnumerable<Mercado> Get()
        {
            MercadosRepository repository = new MercadosRepository();
            List<Mercado> mercados = repository.retrieve();
            return mercados;
        }*/

        
        public IEnumerable<MercadoDTO> Get()
        {
            var repository = new MercadosRepository();
            List<MercadoDTO> mercados = repository.retrieveDTO();
            return mercados;
        }

        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            var repo = new MercadosRepository();
            Mercado mercado = repo.retrieveId(id);
            return mercado;
        }

        // POST: api/Mercado
        public void Post([FromBody] Mercado mercados)
        {
            var repo = new MercadosRepository();
            repo.Save(mercados);
            
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
