using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.BusinessLogic;

using Serilog;
using Microsoft.Extensions.Logging;

namespace CDM_CLIENTS.BusinessLogic
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientTableDB _clientTableDB;

        public ClientLogic(IClientTableDB clientTableDB)
        {
            _clientTableDB = clientTableDB;
            //Log.Logger.Information(" => App is using a BUSINESS LOGIC - Client ");

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

                

                Code = GenerateCodeLetters(newClient.Name) + "-" + newClient.Ci
            };

            if (client.Code != null)
            {
                throw new NameInvalid("Code invalid.");
            }

            // Add to DB
            return DTOUtil.MapClientDTO(_clientTableDB.AddNewClient(client));

        }


        public List<ClientDTO> GetClients()
        {
            //return _clientTableDB.GetAll();
            return DTOUtil.MapClientDTOList(_clientTableDB.GetAll());
        }

        public ClientDTO UpdateClient(string code, ClientDTO clientToUpdate)
        {
            if (code != null)
            {
                throw new NameAlreadyExists("Name already exists.");
            }

            Client client = new Client()
            {
                Name = clientToUpdate.Name,
                Ci = clientToUpdate.Ci,
                Address = clientToUpdate.Address,
                Phone = clientToUpdate.Phone,
                Ranking = clientToUpdate.Ranking,
                Code = GenerateCodeLetters(clientToUpdate.Name) + "-" + clientToUpdate.Ci

            };

            // Add to DB
            return DTOUtil.MapClientDTO(_clientTableDB.UpdateClient(code, client));

        }

        public bool DeleteClient(string code)
        {
            return _clientTableDB.DeleteClient(code);
        }

        public string GenerateCodeLetters(string nombre)
        {
            string letters = "";
            string[] allwords = nombre.Split(' ');
            
            foreach (var word in allwords)
            {
                if( (!string.IsNullOrEmpty(word)) && char.IsLetter(word.ToCharArray() [0]))//!word.Contains("[1-9]") )))
                    letters = letters + (word.ToCharArray() [0]);
            }

            return letters.ToUpper();
        }
    }
}
