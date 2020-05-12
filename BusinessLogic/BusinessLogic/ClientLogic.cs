using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Exceptions;

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
            if(string.IsNullOrEmpty(newClient.Name))
            {
                throw new EmptyNameException("The name field must be filled.");
            }
            if(string.IsNullOrEmpty(newClient.Ci))
            {
                throw new EmptyCiException("The ci field must be filled.");
            }
            if(!(string.IsNullOrEmpty(newClient.Ranking)))
            {
                if(System.Convert.ToInt32(newClient.Ranking) < 0 || System.Convert.ToInt32(newClient.Ranking) > 5)
                {
                    throw new RankingOutOfBoundException("Ranking must be between 0 and 5.");
                }

            }
            
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

            List<ClientDTO> tmp = DTOUtil.MapClientDTOList(_clientTableDB.GetAll());
            ClientDTO tmp_client = tmp.Find(x => x.Code.Contains(client.Code));
            if (tmp_client != null)
            {
                throw new CodeAlreadyExistsException("Invalid code, it already exists, please enter another one");
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
            if(!(string.IsNullOrEmpty(clientToUpdate.Ranking)))
            {
                if(clientToUpdate.Ranking != null && (System.Convert.ToInt32(clientToUpdate.Ranking) < 0 || System.Convert.ToInt32(clientToUpdate.Ranking) > 5))
                {
                    throw new RankingOutOfBoundException("Ranking must be between 0 and 5.");
                }

            }
            
            List<ClientDTO> tmp_list = DTOUtil.MapClientDTOList(_clientTableDB.GetAll());
            ClientDTO tmp_client = tmp_list.Find(x => x.Code.Contains(code));
            if (tmp_client == null)
            {
                throw new CodeDoesNotExistException("Couldn't find code, please enter a valid code");
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


            return DTOUtil.MapClientDTO(_clientTableDB.UpdateClient(code, client));

        }

        public bool DeleteClient(string code)
        {
            List < ClientDTO > tmp_list = DTOUtil.MapClientDTOList(_clientTableDB.GetAll());
            ClientDTO tmp_client = tmp_list.Find(x => x.Code.Contains(code));
            if (tmp_client == null)
            {
                throw new CodeDoesNotExistException("Couldn't find code, please enter a valid code");
            }
            return _clientTableDB.DeleteClient(code);
        }

        public string GenerateCodeLetters(string nombre)
        {
            string letters = "";
            string[] allwords = nombre.Split(' ');

            foreach (var word in allwords)
            {
                if ((!string.IsNullOrEmpty(word)) && char.IsLetter(word.ToCharArray()[0]))//!word.Contains("[1-9]") )))
                    letters = letters + (word.ToCharArray()[0]);
            }

            return letters.ToUpper();
        }
    }
}
