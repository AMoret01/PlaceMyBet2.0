using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Apuestas/{action}")]
    public class Apuestas_Controller : ApiController
    {
        // GET: api/Usuarios_
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Apuestas> Get()
        {
            Repositorio_Apuestas rep = new Repositorio_Apuestas();
            List<Apuestas> lista = rep.retrieve();
            return lista;
        }
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<ApuestasDTO> GetDTO()
        {
            Repositorio_Apuestas rep = new Repositorio_Apuestas();
            List<ApuestasDTO> lista = rep.retrieveDTO();
            return lista;
        }

        // GET: api/Apuestas/5
        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody] Apuestas a)
        {
            var repo = new Repositorio_Apuestas();
            repo.Save(a);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
