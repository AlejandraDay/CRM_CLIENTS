using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDM_CLIENTS.Database;
using CDM_CLIENTS.Database.Models;
using CDM_CLIENTS.DTOModels;

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

            List<RankingDTO> rankingsToAssign = GetEmptyRankings();

            // Process all clients
            foreach (Client client in allClients)
            {
                // Asign Cient to a Group
                assignToRanking(rankingsToAssign, client);
            }

            return rankingsToAssign;
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

        private void assignToRanking(List<RankingDTO> rankingsToAssign, Client client)
        {
            RankingDTO RankingToAssign = rankingsToAssign.Find(Ranking => Ranking.RankingName.Contains(client.Ranking));

            if (RankingToAssign != null && RankingToAssign.Clients.Count < RankingToAssign.MaxNumberOfClients)
            {
                RankingToAssign.Clients.Add(new ClientDTO()
                {
                    Name = client.Name,
                    Ci = client.Ci,
                    Adress = client.Adress,
                    Phone = client.Phone,
                    Ranking = client.Ranking
                });
            }
        }
    }
}
