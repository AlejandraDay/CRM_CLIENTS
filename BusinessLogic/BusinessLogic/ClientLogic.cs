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
        /*
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
            _clientTableDB.AddNewClient(client);

            return client;
        }
        */
        public ClientDTO AddNewClient(ClientDTO newClient)
        {
            // Mappers => function: client.FromDTOtoEntity
            Client client = new Client()
            {
                Name = newClient.Name,
                Ci = newClient.Ci,
                Adress = newClient.Adress,
                Phone = newClient.Phone,
                Ranking = newClient.Ranking,
                Code = Letras(newClient.Name) + "-" + newClient.Ci
            };

            // Add to DB
            Client clientInDB = _clientTableDB.AddNewClient(client);

            // Mappers => function: client.FromEntityToDTO
            return new ClientDTO()
            {
                Name = client.Name,
                Ci = client.Ci,
                Adress = client.Adress,
                Phone = client.Phone,
                Ranking = client.Ranking,
            };
        }
        public List<ClientDTO> GetClients()
        {
            //return _clientTableDB.GetAll();
            List<Client> allClients = _clientTableDB.GetAll();
            List<ClientDTO> clientsdto = new List<ClientDTO>();

            // Mappers
            foreach (Client client in allClients)
            {
                clientsdto.Add(
                    new ClientDTO()
                    {
                        Name = client.Name,
                        Ci = client.Ci,
                        Adress = client.Adress,
                        Phone = client.Phone,
                        Ranking = client.Ranking,
                    }
                );
            }
            return clientsdto;
        }

        public Client UpdateClient(string client_id, ClientDTO clientToUpdate)
        {
            Client client = new Client()
            {
                Name = clientToUpdate.Name,
                Ci = clientToUpdate.Ci,
                Adress = clientToUpdate.Adress,
                Phone = clientToUpdate.Phone,
                Ranking = clientToUpdate.Ranking,
                Code = Letras(clientToUpdate.Name) + "-" + clientToUpdate.Ci
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
