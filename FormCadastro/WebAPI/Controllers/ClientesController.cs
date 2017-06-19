using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        // GET: api/Clientes
        public IEnumerable<UsuarioDTO> GetAll()
        {
            return new UsuarioBLL().LerTodos();
        }

        // GET: api/Clientes/5
        public UsuarioDTO Get(int id)
        {
            return new UsuarioBLL().LerUsuario(id);
        }

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
