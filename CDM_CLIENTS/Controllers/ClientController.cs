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

        // POST (CREATE)
        [HttpPost("Register Client")]
        public ActionResult<Client> AddProduct(string Name, string Id, string Adress, string Phone)
        {
            //  Console.WriteLine(_service.AddClient(Name, Id, Adress, Phone).ToString());
            return _service.AddClient(Name, Id, Adress, Phone);

        }

        // GET (READ)
        [HttpGet("Client List")]
        public ActionResult<List<Client>> GetClients()
        {
            return _service.GetClients();
        }

       

        // PUT (UPDATE)
        [HttpPut("Update ")]
        public ActionResult<Client> UpdateProduct(string client_id, Client client)
        {
            _service.UpdateClient(client_id, client);
            return client;
        }

        // DELETE (DELETE..)
        [HttpDelete("Delete Client")]
        public ActionResult<string> DeleteProduct(string client_id)
        {
            _service.DeleteClient(client_id);
            return client_id;
        }
    }
}
