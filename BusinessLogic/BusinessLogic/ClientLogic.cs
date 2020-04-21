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

        private List<Client> _clients;

        public ClientLogic()
        {
            _clients = new List<Client>();
        }

        public Client AddClient(Client Client)
        {
            Client.Client_id = Letras(Client.Name) + "-" + Client.Id;
            _clients.Add(Client);
            return Client;
        }

        public string DeleteClient(string Client_id)
        {
            for (var i = _clients.Count - 1; i >= 0; i--)
            {
                if (_clients[i].Client_id == Client_id)
                {
                    _clients.RemoveAt(i);
                }
            }

            return Client_id;
        }

        public List<Client> GetClients()
        {
            return _clients;
        }

        public Client UpdateClient(string Client_id, Client Client)
        {
            for (var i = _clients.Count - 1; i >= 0; i--)
            {
                if (_clients[i].Client_id == Client_id)
                {
                    _clients[i] = Client;
                    _clients[i].Client_id = Letras(_clients[i].Name) + "-" + _clients[i].Id;
                }
            }
            return Client;
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
