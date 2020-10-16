using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Apuestas_Controller : ApiController
    {
        // GET: api/Usuarios_
        public IEnumerable<ApuestasDTO> Get()
        {
            var repositorio = new Repositorio_Apuestas();
            List<ApuestasDTO> apuesta = repositorio.retrieveDTO();
            return apuesta;
        }

        // GET: api/Usuarios_/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuarios_
        public void Post([FromBody]Apuestas ap)
        {
            var repo = new Repositorio_Apuestas();
            repo.Save(ap);
        }

        // PUT: api/Usuarios_/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios_/5
        public void Delete(int id)
        {
        }
    }
}
