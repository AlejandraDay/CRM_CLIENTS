using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.Database
{
    public class ClientTableDB:IClientTableDB
    {
        private List<Client> Clients { get; set; }

        public ClientTableDB()
        {
            Clients = new List<Client>(); 
        }

        public Client AddNewClient(Client newClient)
        {
            Clients.Add(newClient);
            return newClient;
        }

        public List<Client> GetAll()
        {
            return Clients;
        }

        public Client UpdateClient(string code, Client clientToUpdate)
        {
            Client client = null;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Code == code)
                {
                    Clients[i] = clientToUpdate;
                    client = clientToUpdate;
                }
            }
            return client;
        }

        public Client DeleteClient(string code)
        {
            Client client = null;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Code == code)
                {
                    client = Clients[i];
                    Clients.RemoveAt(i);   
                }
            }
            return client;
        }
    }
}
