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

        public Client AddNewClient(ClientDTO newClient)
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
            return _clientTableDB.AddNewClient(client);
        }

        public List<Client> GetClients()
        {
            //return _clientTableDB.GetAll();
            return _clientTableDB.GetAll();
        }

        public Client UpdateClient(string code, ClientDTO clientToUpdate)
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
            return _clientTableDB.UpdateClient(code, client);
        }

        public Client DeleteClient(string code)
        {
            return _clientTableDB.DeleteClient(code);
        }

        public string Letras(string nombre)
        {
            string Letras = "";
            char[] Cut = new char[nombre.Length];

            Cut = nombre.ToCharArray();

            foreach (char c in Cut)
            {
                if (char.IsUpper(c))
                {
                    Letras = Letras + c;
                }
            }
            return Letras;
        }
    }
}
