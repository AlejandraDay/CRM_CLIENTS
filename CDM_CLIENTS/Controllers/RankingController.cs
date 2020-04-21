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
    [Route("api/[controller]")]
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
            return _rankingLogic.GetRankingsCERTClass();
        }




        // GET: api/Ranking/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ranking
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Ranking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
