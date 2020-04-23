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

namespace CDM_CLIENTS.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ILogger _logger;
        private readonly IClientLogic _clientLogic;


        public ClientController(ILogger<ClientController> logger, IClientLogic clientLogic)
        {
            _logger = logger;
            _clientLogic = clientLogic;
        }

        // POST (CREATE)
        [HttpPost]
        [Route("clients")]
        public ActionResult<Client> AddProduct([FromBody]ClientDTO newClient)
        {
            return _clientLogic.AddClient(newClient);
        }

        // GET (READ)
        [HttpGet]
        [Route("clients")]
        public ActionResult<List<Client>> GetClients()
        {
            return _clientLogic.GetClients();
        }

       

        // PUT (UPDATE)
        [HttpPut]
        [Route("clients/{client_id}")]
        public ActionResult<Client> UpdateProduct(string client_id, [FromBody]ClientDTO clientToUpdate)
        {
            return _clientLogic.UpdateClient(client_id, clientToUpdate);
        }

        // DELETE (DELETE)
        [HttpDelete]
        [Route("clients/{client_id}")]
        public ActionResult<Client> DeleteProduct(string client_id)
        {
            return _clientLogic.DeleteClient(client_id);
        }
    }
}
