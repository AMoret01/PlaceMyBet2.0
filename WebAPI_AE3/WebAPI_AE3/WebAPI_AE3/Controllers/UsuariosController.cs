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
    public class UsuariosController : ApiController
    {
        // GET: api/Usuario_
        public IEnumerable<Usuario> Get()
        {
            var repository = new UsuariosRepository();
            List<Usuario> usuarios = repository.retrieve();
            return usuarios;
        }

        // GET: api/Usuario_/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario_
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Usuario_/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Usuario_/5
        public void Delete(int id)
        {
        }
    }
}
