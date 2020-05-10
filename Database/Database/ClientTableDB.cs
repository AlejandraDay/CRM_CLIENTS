using CDM_CLIENTS.Database.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CDM_CLIENTS.Database
{
    public class ClientTableDB:IClientTableDB
    {
        private readonly IConfiguration _configuration;
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
            Client client = null;
            for (int i = 0; i < _clientList.Count; i++)
            {
                if (_clientList[i].Code == code)
                {
                    _clientList[i] = clientToUpdate;
                    client = clientToUpdate;
                }
            }
            SaveChanges();
            return client;
        }

        public Client DeleteClient(string code)
        {
            Client client = null;
            for (int i = 0; i < _clientList.Count; i++)
            {
                if (_clientList[i].Code == code)
                {
                    client = _clientList[i];
                    _clientList.RemoveAt(i);   
                }
            }
            SaveChanges();
            return client;
        }
    }
}
