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
    
    public class ApuestaController : ApiController
    {
        // GET: api/Apuesta
        
        public IEnumerable<Apuesta> Get()
        {
            ApuestasRepository rep = new ApuestasRepository();
            List<Apuesta> lista = rep.retrieve();
            return lista;
        }
        
        public IEnumerable<ApuestaDTO> GetDTO()
        {
            var repository = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repository.retrieveDTO();
            return apuestas;
        }

        // GET: api/Apuesta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuesta
        public void Post([FromBody] Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
