using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.Database
{
    public interface IClientTableDB
    {
        public void  AddClient(Client client);
        public List<Client> GetAll();

    }
}
