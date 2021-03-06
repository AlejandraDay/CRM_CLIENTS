﻿using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.Database.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Microsoft.Extensions.Logging;
using Serilog;

namespace CDM_CLIENTS.Database
{
    public class ClientTableDB:IClientTableDB
    {
        private readonly IConfiguration _configuration;

        public readonly ILogger<ClientTableDB> _logger;
        private string _dbPath;
        private List<Client> _clientList;
        private DBContext _dbContext;

        public ClientTableDB(IConfiguration configuration)
        {
            _configuration = configuration;

            InitDBContext();
        }

        public void InitDBContext()
        {
             try
            {
                _dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;

                Log.Logger.Information(" => App is using a DATABASE -> path : " + _dbPath);

                _dbContext = JsonConvert.DeserializeObject<DBContext>(File.ReadAllText(_dbPath));

                _clientList = _dbContext.Client;
            }
            catch (Exception)
            {       
                Log.Logger.Error(" => Connection with DATABASE is not working : " + _dbPath);        
                throw new DatabaseException("Connection with Database is not working!");
            }
        }

        public void SaveChanges()
        {
            File.WriteAllText(_dbPath, JsonConvert.SerializeObject(_dbContext));
        }

        public Client AddNewClient(Client newClient)
        {
            _clientList.Add(newClient);
            SaveChanges();
            
            return newClient;
        }

        public List<Client> GetAll()
        {
            return _clientList;
        }

        public Client UpdateClient(string code, Client clientToUpdate)
        {
            Client clientFound = _clientList.Find(client => client.Code == code);
            if(clientFound != null)
            {

                  
                if((!string.IsNullOrEmpty(clientToUpdate.Name)) && string.IsNullOrEmpty(clientToUpdate.Ci))
                {
    
                    clientFound.Code = clientToUpdate.Code.Split('-') [0] + "-" + clientFound.Ci;
                    clientFound.Name = clientToUpdate.Name;

                }
                else if((!string.IsNullOrEmpty(clientToUpdate.Ci)) && string.IsNullOrEmpty(clientToUpdate.Name))
                {
                        clientFound.Code = clientFound.Code.Split('-') [0] + "-" + clientToUpdate.Ci;
                        clientFound.Ci = clientToUpdate.Ci;
                } 
                else if((!string.IsNullOrEmpty(clientToUpdate.Ci)) && (!string.IsNullOrEmpty(clientToUpdate.Name)))
                {
                    clientFound.Code = clientToUpdate.Code;
                    clientFound.Name = clientToUpdate.Name;
                    clientFound.Ci = clientToUpdate.Ci;
                }
                
                if(string.IsNullOrEmpty(clientToUpdate.Address))
                {
                    clientToUpdate.Address = clientFound.Address;
                }else{
                    clientFound.Address = clientToUpdate.Address;
                }
                if(string.IsNullOrEmpty(clientToUpdate.Phone))
                {
                    clientToUpdate.Phone = clientFound.Phone;
                }else{
                    clientFound.Phone = clientToUpdate.Phone;
                }
                if(string.IsNullOrEmpty(clientToUpdate.Ranking))
                {
                    clientToUpdate.Ranking = clientFound.Ranking;
                }else{
                    clientFound.Ranking = clientToUpdate.Ranking;
                }
                
            }
            SaveChanges();
            Log.Logger.Information(" => Data for the Client : {0} was modified in the DataBase", clientFound.Code );

            return clientFound;
        }

        public bool DeleteClient(string code)
        {
            Client clientFound = _clientList.Find(client => client.Code == code);
            bool wasRemoved = _clientList.Remove(clientFound);
            SaveChanges();
            Log.Logger.Information(" => The Client : {0} has been deleted from the DataBase", code );
            return wasRemoved;
        }
    }
}
