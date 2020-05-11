using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.BusinessLogic.Exceptions;

namespace CDM_CLIENTS.BusinessLogic
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientTableDB _clientTableDB;

        public ClientLogic(IClientTableDB clientTableDB)
        {
            _clientTableDB = clientTableDB;
        }

        public ClientDTO AddNewClient(ClientDTO newClient)
        {

            // Mappers => function: client.FromDTOtoEntity
            Client client = new Client()
            {
                Name = newClient.Name,
                Ci = newClient.Ci,
                Address = newClient.Address,
                Phone = newClient.Phone,
                Ranking = newClient.Ranking,
                Code = Letras(newClient.Name) + "-" + newClient.Ci

            };

            if (Code != null)
            {
                throw new NameAlreadyExists("Name already exists.");
            }

            try
            {
                // Add to DB
                return DTOUtil.MapClientDTO(_clientTableDB.AddNewClient(client));
            }

            catch (NameAlreadyExists qd)
            {
                throw qd;
            }
        }

        public List<ClientDTO> GetClients()
        {
            //return _clientTableDB.GetAll();
            return DTOUtil.MapClientDTOList(_clientTableDB.GetAll());
        }

        public ClientDTO UpdateClient(string code, ClientDTO clientToUpdate)
        {

            Client client = new Client()
            {
                Name = clientToUpdate.Name,
                Ci = clientToUpdate.Ci,
                Address = clientToUpdate.Address,
                Phone = clientToUpdate.Phone,
                Ranking = clientToUpdate.Ranking
            };

            if (code != null)
            {
                throw new NameAlreadyExists("Name already exists.");
            }

            try
            {
                // Add to DB
                return DTOUtil.MapClientDTO(_clientTableDB.UpdateClient(code, client));
            }

            catch (NameAlreadyExists qd)
            {
                throw qd;
            }
            
        }

        public bool DeleteClient(string code)
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
