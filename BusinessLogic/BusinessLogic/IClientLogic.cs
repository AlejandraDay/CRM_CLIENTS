using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDM_CLIENTS.BusinessLogic
{
    public interface IClientLogic
    {
        public Client AddNewClient(ClientDTO newClient);
        public List<Client> GetClients();
        public Client UpdateClient(string code, ClientDTO clientToUpdate);
        public Client DeleteClient(string code);
    }
}
