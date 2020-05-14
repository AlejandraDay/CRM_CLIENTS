using System;
using System.Collections.Generic;
using System.Text;
using CDM_CLIENTS.Database.Models;

namespace CDM_CLIENTS.DTOModels
{
    public class DTOUtil
    {
        public static ClientDTO MapClientDTO(Client client) 
        {
            ClientDTO clientDTO = new ClientDTO();

            clientDTO.Name = client.Name;
            clientDTO.Ci = client.Ci;
            clientDTO.Address = client.Address;
            clientDTO.Phone = client.Phone;
            clientDTO.Ranking = client.Ranking;
            clientDTO.Code = client.Code;

            return clientDTO;
        }

        public static List<ClientDTO> MapClientDTOList(List<Client> clientList) 
        {
            List<ClientDTO> clientDTOList = new List<ClientDTO>();

            foreach (Client client in clientList)
            {
                clientDTOList.Add
                (
                    new ClientDTO()
                    {
                        Name = client.Name,
                        Ci = client.Ci,
                        Address = client.Address,
                        Phone = client.Phone,
                        Ranking = client.Ranking,
                        Code = client.Code
                    }
                );
            }

            return clientDTOList;
        }
    }
}
