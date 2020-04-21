using CDM_CLIENTS.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.BusinessLogic
{
    public interface IRankingLogic
    {
        public List<RankingDTO> GetRankingsCERTClass();
    }
}
