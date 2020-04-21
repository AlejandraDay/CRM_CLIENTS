using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDM_CLIENTS.BusinessLogic;
using CDM_CLIENTS.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDM_CLIENTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        
        private readonly  IRankingLogic _clientsLogic; //Requiere modificacion para que sean listas de clientes 

        public ClientController(IRankingLogic clienteLogic)
        {
            _clientsLogic = clienteLogic;
        }
        

        // GET: api/Client //Read
        [HttpGet]
        public IEnumerable<RankingDTO> GetAll()
        {
          //  return _rankingLogic.
          return _clientsLogic.GetRankingsCERTClass();
        }


        // POST: api/Client //update (if i'm not wrong)
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Client/5 //create (if i'm not wrong)
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
