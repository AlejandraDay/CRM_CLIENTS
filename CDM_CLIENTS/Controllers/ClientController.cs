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
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ILogger _logger;
        private IClientLogic _service;


        public ClientController(ILogger<ClientController> logger, IClientLogic service)
        {
            _logger = logger;
            _service = service;

        }

        // GET (READ)
        [HttpGet("/api/clients")]
        public ActionResult<List<Client>> GetClients()
        {
            return _service.GetClients();
        }

        // POST (CREATE)
        [HttpPost("/api/clients")]
        public ActionResult<Client> AddProduct(Client client)
        {
            _service.AddClient(client);
            return client;
        }

        // PUT (UPDATE)
        [HttpPut("/api/clients/{client_id}")]
        public ActionResult<Client> UpdateProduct(string client_id, Client client)
        {
            _service.UpdateClient(client_id, client);
            return client;
        }

        // DELETE (DELETE..)
        [HttpDelete("/api/clients/{client_id}")]
        public ActionResult<string> DeleteProduct(string client_id)
        {
            _service.DeleteClient(client_id);
            return client_id;
        }
    }
}
