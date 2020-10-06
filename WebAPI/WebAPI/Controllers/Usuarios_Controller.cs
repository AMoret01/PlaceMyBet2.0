using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Usuarios_Controller : ApiController
    {
        // GET: api/Usuario_
        public IEnumerable<Usuario> Get()
        {
            var repositorio = new Repositorio_Usuario();
            List<Usuario> usuarios= repositorio.retrieve();
            return usuarios;
        }

        // GET: api/Usuario_/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario_
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario_/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario_/5
        public void Delete(int id)
        {
        }
    }
}
