using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using WebAPI_AE4.Models;

namespace WebAPI_AE4.Controllers
{
    [Route("api/Apuesta/{action}")]
    public class Apuestas_Controller : ApiController
    {
        // GET: api/Apuesta
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Apuesta> Get()
        {
            Repositorio_Apuestas rep = new Repositorio_Apuestas();
            List<Apuesta> lista = rep.retrieve();
            return lista;
        }
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<ApuestaDTO> GetDTO()
        {
            var repository = new Repositorio_Apuestas();
            List<ApuestaDTO> apuestas = repository.retrieveDTO();
            return apuestas;
        }

        [Authorize(Roles = "Admin")]
        public IEnumerable<Apuesta> GetUsuario(double tipo_Mercado, string email)
        {
            var repo = new Repositorio_Apuestas();
            List<Apuesta> apuesta = repo.GetUsuario(tipo_Mercado, email);
            return apuesta;
        }
        [Authorize(Roles = "Admin")]
        public IEnumerable<Apuesta> GetMercado(double tipo_Mercado, string email)
        {
            var repo = new Repositorio_Apuestas();
            List<Apuesta> apuesta = repo.GetMercado(tipo_Mercado, email);
            return apuesta;
        }

        [Authorize(Roles = "Admin")]
        public void Post([FromBody] Apuesta apuesta)
        {
            var rep = new Repositorio_Apuestas();
            rep.Save(apuesta);
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
