using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDM_CLIENTS.BusinessLogic
{
    public interface IClientLogic
    {
        public List<Client> GetClients();

        public Client AddClient(Client Client);

        public Client UpdateClient(string Client_id, Client Client);

        public string DeleteClient(string Client_id);
    }
}
