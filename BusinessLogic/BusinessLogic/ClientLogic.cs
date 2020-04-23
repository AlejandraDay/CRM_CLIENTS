using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;
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

        public Client AddClient(ClientDTO newClient)
        {
            Client client = new Client()
            {
                Name = newClient.Name, 
                Id = newClient.Id,
                Adress = newClient.Adress,
                Phone = newClient.Phone,
                Ranking = newClient.Ranking,
                Client_id = Letras(newClient.Name) + "-" + newClient.Id
            };
            _clientTableDB.AddClient(client);

            return client;
        }

        public List<Client> GetClients()
        {
            return _clientTableDB.GetAll();
        }

        public Client UpdateClient(string client_id, ClientDTO clientToUpdate)
        {
            Client client = new Client()
            {
                Name = clientToUpdate.Name,
                Id = clientToUpdate.Id,
                Adress = clientToUpdate.Adress,
                Phone = clientToUpdate.Phone,
                Ranking = clientToUpdate.Ranking,
                Client_id = Letras(clientToUpdate.Name) + "-" + clientToUpdate.Id
            };
            return _clientTableDB.UpdateClient(client_id, client);
        }

        public Client DeleteClient(string client_id)
        {
            return _clientTableDB.DeleteClient(client_id);
        }

        public String Letras(String nombre)
        {
            String Letras = "";
            char[] Cut = new char[nombre.Length];

            Cut = nombre.ToCharArray();

            foreach (char c in Cut)
            {
                if (Char.IsUpper(c))
                {
                    Letras = Letras + c;
                }
            }
            return Letras;
        }
    }
}
