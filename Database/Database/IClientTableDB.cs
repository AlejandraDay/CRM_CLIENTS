using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.Database
{
    public interface IClientTableDB: IDBManager
    {
        public Client AddNewClient(Client newClient);
        public List<Client> GetAll();
        public Client UpdateClient(string client_id, Client clientToUpdate);
        public Client DeleteClient(string client_id);
    }
}
