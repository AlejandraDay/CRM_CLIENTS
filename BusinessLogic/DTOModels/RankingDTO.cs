using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.DTOModels
{
    public class RankingDTO
    {   
        public string RankingName { get; set; }
        // "John Smith", "Paul", ......
        public List<ClientDTO> Clients { get; set; }
        //getStudents / setStudents

        public int MaxNumberOfRanks { get; set; }
    }
}
