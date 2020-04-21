using CDM_CLIENTS.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;

namespace CDM_CLIENTS.BusinessLogic
{
    public class RankingLogic : IRankingLogic
    {
        private readonly IClientTableDB _clientTableDB;

        public RankingLogic(IClientTableDB clientTableDB)
        {
            _clientTableDB = clientTableDB;
        }

        public List<RankingDTO> GetRankings()
        {
            // Retrieve all clients from database
            List<Client> allClients = _clientTableDB.GetAll();

            List<RankingDTO> rankingToAssign = GetEmptyRankings();

            // Process all clients
            foreach (Client client in allClients)
            {
                // Asign Cient to a Group
                assignToRanking(rankingToAssign, client);
            }

            return rankingToAssign;
        }

        private List<RankingDTO> GetEmptyRankings()
        {
            List<RankingDTO> emptyRankings = new List<RankingDTO>()
            {
                new RankingDTO() {RankingName="Ranking 1", Clients=new List<ClientDTO>(), MaxNumberOfClients=100 },
                new RankingDTO() {RankingName="Ranking 2", Clients=new List<ClientDTO>(), MaxNumberOfClients=100 },
                new RankingDTO() {RankingName="Ranking 3", Clients=new List<ClientDTO>(), MaxNumberOfClients=100 },
                new RankingDTO() {RankingName="Ranking 4", Clients=new List<ClientDTO>(), MaxNumberOfClients=100 },
                new RankingDTO() {RankingName="Ranking 5", Clients=new List<ClientDTO>(), MaxNumberOfClients=100 },
            };
            return emptyRankings;
        }

        private void assignToRanking(List<RankingDTO> RankingsToAssign, Client client)
        {
            RankingDTO RankingToAssign = RankingsToAssign.Find(Ranking => Ranking.RankingName.Contains(client.Ranking));

            if (RankingToAssign != null && RankingToAssign.Clients.Count < RankingToAssign.MaxNumberOfClients)
            {
                RankingToAssign.Clients.Add(new ClientDTO() { Client_id = client.Client_id });
            }
        }
    }
}
