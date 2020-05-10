using CDM_CLIENTS.Database.Models;
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
            _dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;

            Log.Logger.Information("  => App is using a DATABASE -> path : " + _dbPath);

            _dbContext = JsonConvert.DeserializeObject<DBContext>(File.ReadAllText(_dbPath));

            _clientList = _dbContext.Client;
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
                if(string.IsNullOrEmpty(clientToUpdate.Name))
                {
                    clientToUpdate.Name = clientFound.Name;
                }else{
                    clientFound.Name = clientToUpdate.Name;
                }
                if(string.IsNullOrEmpty(clientToUpdate.Ci))
                {
                    clientToUpdate.Ci = clientFound.Ci;
                }else{
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
            return clientFound;
        }

        public bool DeleteClient(string code)
        {
            Client clientFound = _clientList.Find(client => client.Code == code);
            bool wasRemoved = _clientList.Remove(clientFound);
            SaveChanges();
            return wasRemoved;
        }
    }
}
