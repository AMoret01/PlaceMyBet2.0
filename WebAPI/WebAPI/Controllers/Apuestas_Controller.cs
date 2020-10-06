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
        public IEnumerable<Apuestas> Get()
        {
            var repositorio = new Repositorio_Apuestas();
            List<Apuestas> apuestas = repositorio.retrieve();
            return apuestas;
        }

        // GET: api/Usuarios_/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuarios_
        public void Post([FromBody]string value)
        {
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
