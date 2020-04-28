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
        private ILogger _logger;
        private readonly IClientLogic _clientLogic;
        private readonly IConfiguration _configuration;

        public ClientController(ILogger<ClientController> logger, IClientLogic clientLogic, IConfiguration config)
        {
            _logger = logger;
            _clientLogic = clientLogic;
            _configuration = config;
        }

        // POST (CREATE)
        [HttpPost]
        [Route("clients")]
        public ActionResult<ClientDTO> AddProduct([FromBody]ClientDTO newClientdto)
        {
            ClientDTO newClient = _clientLogic.AddNewClient(newClientdto);

            var dbServer = _configuration.GetSection("Database").GetSection("ConnectionString");

            newClient.Name = $"{newClient.Name} data from {dbServer.Value}";

            return newClient;
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
        public ActionResult<Client> UpdateProduct(string code, [FromBody]ClientDTO clientToUpdate)
        {
            return _clientLogic.UpdateClient(code, clientToUpdate);
        }

        // DELETE (DELETE)
        [HttpDelete]
        [Route("clients/{code}")]
        public ActionResult<Client> DeleteProduct(string code)
        {
            return _clientLogic.DeleteClient(code);
        }
    }
}
