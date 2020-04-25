using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.Database
{
    public class ClientTableDB:IClientTableDB
    {
        private List<Client> Clients { get; set; }

        public ClientTableDB()
        {
            Clients = new List<Client>(); 
        }

        public Client AddNewClient(Client newClient)
        {
            Clients.Add(newClient);
            return newClient;
        }

        public List<Client> GetAll()
        {
            return Clients;
            /*{new Client() { Name = "Juan Manuel Martinez Rojas", Id = "600541", Adress = "Av. América", Phone = "65494012", Ranking = "1", Client_id = "JMMR-600541" },new Client() { Name = "Rocio María Flores Rios", Id = "5315406", Adress = "Av. Circunvalación", Phone = "78690019", Ranking = "2", Client_id = "RMFR-5315406" },new Client() { Name = "Bianca Mercedes Siles Céspedes", Id = "831648", Adress = "Av. Meclchor Urquidi", Phone = "73654200", Ranking = "2", Client_id = "BMSC-831648" },new Client() { Name = "Samuel Oscar Nabarro Yáñez", Id = "3026982", Adress = "Av. Libertadores", Phone = "66320140", Ranking = "5", Client_id = "SONY-3026982" },new Client() { Name = "Nicholas Ignacius Klopp Espada", Id = "9002563", Adress = "Av. Ayacucho", Phone = "73294605", Ranking = "5", Client_id = "NIKE-9002563" }};*/
        }

        public Client UpdateClient(string client_id, Client clientToUpdate)
        {
            Client client = null;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Client_id == client_id)
                {
                    Clients[i] = clientToUpdate;
                    client = clientToUpdate;
                }
            }
            return client;
        }

        public Client DeleteClient(string client_id)
        {
            Client client = null;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Client_id == client_id)
                {
                    client = Clients[i];
                    Clients.RemoveAt(i);   
                }
            }
            return client;
        }
    }
}
