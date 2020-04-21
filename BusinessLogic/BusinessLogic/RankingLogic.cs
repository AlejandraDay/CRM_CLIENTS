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

        public RankingLogic(IClientTableDB studentTableDB)
        {
            _clientTableDB = studentTableDB;
        }

        public List<RankingDTO> GetRankingsCERTClass()
        {
            // Retrieve all clients from database
            List<Client> allClients = _clientTableDB.GetAll();

            List<RankingDTO> rankingToAssign = GetEmptyRankings();

            List<Client> unOrderClientList = allClients.OrderBy(client => new Random().Next()).ToList();
            // Process all clients
            foreach (Client client in unOrderClientList)
            {
                // Student choose a Ranking
                int rankingNumber = GetARankingNumber();
                assignToRanking(rankingNumber, rankingToAssign, client);
            }

            return rankingToAssign;
        }

        private List<RankingDTO> GetEmptyRankings()
        {
            List<RankingDTO> emptyRankings = new List<RankingDTO>()
            {
                new RankingDTO() {RankingName="Grupo 1", Clients=new List<ClientDTO>(), MaxNumberOfRanks=4 },
                new RankingDTO() {RankingName="Grupo 2", Clients=new List<ClientDTO>(), MaxNumberOfRanks=4 },
                new RankingDTO() {RankingName="Grupo 3", Clients=new List<ClientDTO>(), MaxNumberOfRanks=4 },
                new RankingDTO() {RankingName="Grupo 4", Clients=new List<ClientDTO>(), MaxNumberOfRanks=5 },
                new RankingDTO() {RankingName="Grupo 5", Clients=new List<ClientDTO>(), MaxNumberOfRanks=5 },
            };
            return emptyRankings;
        }

        private int GetARankingNumber()
        {
            return new Random().Next(1, 6);
        }

        private void assignToRanking(int RankingNumber, List<RankingDTO> RankingsToAssign, Client client)
        {
            RankingDTO RankingToAssign = RankingsToAssign.Find(Ranking => Ranking.RankingName.Contains(RankingNumber.ToString()));

            if (RankingToAssign != null && RankingToAssign.Clients.Count < RankingToAssign.MaxNumberOfRanks)
            {
                RankingToAssign.Clients.Add(new ClientDTO() { Name = client.Name });
                return;
            }
            else
            {
                int newRankingNumber = GetARankingNumber();
                assignToRanking(newRankingNumber, RankingsToAssign, client);
            }
        }
    }
}
