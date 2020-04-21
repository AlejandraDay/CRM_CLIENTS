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
    [Route("api/clients")]
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
        [HttpPut("Update")]
        public ActionResult<Client> UpdateProduct(string Client_id, string Name, string Id, string Adress, string Phone, string Ranking)
        {
            return _service.UpdateClient(Client_id, new Client() {Name=Name, Id=Id, Adress=Adress, Phone=Phone, Ranking=Ranking, Client_id=Client_id}); ;
        }

        // DELETE (DELETE..)
        [HttpDelete("Delete Client")]
        public ActionResult<Client> DeleteProduct(string Client_id)
        {
            return _service.DeleteClient(Client_id);
        }
    }
}
