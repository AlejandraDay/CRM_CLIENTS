using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDM_CLIENTS.BusinessLogic
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientTableDB _clientTableDB;

        public ClientLogic(IClientTableDB clientTableDB)
        {
            _clientTableDB = clientTableDB;
        }
        public List<Client> GetClients()
        {
            // Retrieve all clients from database
            List<Client> allClients = _clientTableDB.GetAll();

            return allClients;
        }
    }
}
