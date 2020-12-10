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
    
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        
        /*public IEnumerable<Mercado> Get()
        {
            MercadosRepository repository = new MercadosRepository();
            List<Mercado> mercados = repository.retrieve();
            return mercados;
        }*/

        
        public IEnumerable<MercadoDTO> GetDTO()
        {
            var repository = new MercadosRepository();
            List<MercadoDTO> mercados = repository.retrieveDTO();
            return mercados;
        }

        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            var repository = new MercadosRepository();
            Mercado mercados = repository.Retrieve(id);
            return mercados;
        }

        // POST: api/Mercado
        public void Post([FromBody] string value)
        {
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
