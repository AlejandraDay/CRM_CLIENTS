using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDM_CLIENTS.BusinessLogic
{
    public interface IClientLogic
    {
        public ClientDTO AddNewClient(ClientDTO newClient);
        public List<ClientDTO> GetClients();
        public Client UpdateClient(string client_id, ClientDTO clientToUpdate);
        public Client DeleteClient(string client_id);
    }
}
