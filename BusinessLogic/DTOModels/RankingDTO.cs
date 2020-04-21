using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.DTOModels
{
    public class RankingDTO
    {   
        public string RankingName { get; set; }

        public List<ClientDTO> Clients { get; set; }

        public int MaxNumberOfClients { get; set; }
    }
}
