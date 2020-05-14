using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDM_CLIENTS.BusinessLogic;
using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CDM_CLIENTS.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _clientLogic;

        public ClientController(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }

        // POST (CREATE)
        [HttpPost]
        [Route("clients")]
        public ClientDTO AddProduct([FromBody]ClientDTO newClientdto)
        {
            return _clientLogic.AddNewClient(newClientdto);
        }

        // GET (READ)
        [HttpGet]
        [Route("clients")]
        public ActionResult<List<ClientDTO>> GetClients()
        {
            return _clientLogic.GetClients();
        }

       

        // PUT (UPDATE)
        [HttpPut]
        [Route("clients/{code}")]
        public ActionResult<ClientDTO> UpdateProduct(string code, [FromBody]ClientDTO clientToUpdate)
        {
            return _clientLogic.UpdateClient(code, clientToUpdate);
        }

        // DELETE (DELETE)
        [HttpDelete]
        [Route("clients/{code}")]
        public bool DeleteProduct(string code)
        {
            return _clientLogic.DeleteClient(code);
        }
    }
}
