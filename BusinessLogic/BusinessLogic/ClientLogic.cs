using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CDM_CLIENTS.BusinessLogic
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientTableDB _clientTableDB;

        //private List<Client> _clients;

        public ClientLogic(IClientTableDB clientTableDB)
        {
            //_clients = new List<Client>();
            _clientTableDB = clientTableDB;
        }

       /* public Client AddClient(Client Client)
        {
            Client.Client_id = Letras(Client.Name) + "-" + Client.Id;
            _clients.Add(Client);
            return Client;
        }*/
        public Client AddClient(string name, string id, string adress, string phone)
        {
            string client_id = Letras(name) + "-" + id;

            Client client = new Client()
            {
                Name = name, Id = id,
                Adress = adress,
                Phone = phone,
                Client_id = client_id, 
                Ranking = "1"
            };
            _clientTableDB.AddClient(client);

            return client;
        }

        public Client DeleteClient(string Client_id)
        {
            /*for (var i = _clients.Count - 1; i >= 0; i--)
            {
                if (_clients[i].Client_id == Client_id)
                {
                    _clients.RemoveAt(i);
                }
            }*/

            return _clientTableDB.DeleteClient(Client_id);
        }

        public List<Client> GetClients()
        {

          //  foreach(Client objClient in _clientTableDB.GetAll())
          //  {
          //      Console.WriteLine(objClient.Adress, objClient.Client_id);
          //  }
            return _clientTableDB.GetAll();
        }

        public Client UpdateClient(string Client_id, Client Client)
        {
            /*for (var i = _clients.Count - 1; i >= 0; i--)
            {
                if (_clients[i].Client_id == Client_id)
                {
                    _clients[i] = Client;
                    _clients[i].Client_id = Letras(_clients[i].Name) + "-" + _clients[i].Id;
                    break;
                }
            }*/
            Client updatedClient = Client;
            updatedClient.Client_id = Letras(Client.Name) + "-" + Client.Id;
            return _clientTableDB.UpdateClient(Client_id, updatedClient);
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
