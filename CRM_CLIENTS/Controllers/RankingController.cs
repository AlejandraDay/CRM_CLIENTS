using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CDM_CLIENTS.BusinessLogic;
using CDM_CLIENTS.DTOModels;

namespace CDM_CLIENTS.Controllers
{
    [Route("api/rankings")]
    [ApiController]
    public class RankingController : ControllerBase
    {


        private readonly IRankingLogic _rankingLogic;

        public RankingController(IRankingLogic rankingLogic)
        {
            _rankingLogic = rankingLogic;
        }


        // GET: api/Client //Read
        [HttpGet]
        public IEnumerable<RankingDTO> GetAll()
        {
            //  return _rankingLogic.
            return _rankingLogic.GetRankings();
        }

    }
}
