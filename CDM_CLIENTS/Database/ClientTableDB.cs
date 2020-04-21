using CDM_CLIENTS.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDM_CLIENTS.Database
{
    public class ClientTableDB
    {
        public List<Client> GetAll()
        {
            return new List<Client>()
            {
                new Client() { Name="CARLOS GABRIEL  ACOSTA CLAROS   ", Email="gabrielacoata@gmail.com"},
                new Client() { Name="CARLA ANDREA    BARRIENTOS MUÑOZ    ", Email="carla.andrea.cbm@gmail.com"},
                new Client() { Name="PEDRO ANDRES    BRAñEZ CADIMA   ", Email="pedrobran8@gmail.com "},
                new Client() { Name="CESAR ALEJANDRO BUENO AZURDUY   ", Email="alebuenoaz@gmail.com"},
                new Client() { Name="VANESSA GABRIELA    BUSTILLOS NAJERA    ", Email="vanebustillos1@gmail.com"},
                new Client() { Name="FROILAN JOSUE   CARDOZO ZAMBRANA    ", Email="jsosueczf@gmail.com"},
                new Client() { Name="RICARDO ALEXANDER   FERNANDEZ BENAVIDES ", Email="humanoastuto321@gmail.com"},
                new Client() { Name="ANDRES  GAMBOA BALDI    ", Email="andresgamboabaldi@gmail.com"},
                new Client() { Name="JUAN DIEGO  GARCIA VARGAS   ", Email="juandigv69@gmail.com"},
                new Client() { Name="PEDRO GERARDO   GONZALEZ POZO   ", Email="ggonzalezpozopedro@gmail.com"},
                new Client() { Name="RODRIGO NICOLAS HEREDIA ALCOCER ", Email="rodrigoh1205@gmail.com"},
                new Client() { Name="MATEO   LOPEZ LEDEZMA   ", Email="lm67427572@gmail.com"},
                new Client() { Name="RUBEN ALEJANDRO MALDONADO FUENTES   ", Email="romancalle14@gmail.com"},
                new Client() { Name="ANA PAOLA   MONTERO CASSAB  ", Email="anapao.montero@gmail.com"},
                new Client() { Name="BRAMI ATMANI    PRUDENCIO RODRIGUEZ ", Email="bramopit@gmail.com"},
                new Client() { Name="ALEJANDRA DAYANA    QUELALI CALCINA ", Email="alejandra.day.123@gmail.com"},
                new Client() { Name="PABLO   RIVAS   ", Email="pabloperedo04@gmail.com"},
                new Client() { Name="MELISA  ROJAS SORIA ", Email="melisa.rs.1990@gmail.com"},
                new Client() { Name="DIEGO ALEJANDRO ROSAZZA MERIDA  ", Email="diegorosazza@gmail.com"},
                new Client() { Name="STEFANO DANIEL  SOSSI ROJAS ", Email="tenosossi2012@gmail.com "},
                new Client() { Name="VINCENT ALEJANDRO   VALENZUELA ISPAN    ", Email="note234vnt@gmail.com"},
                new Client() { Name="ANDREA NATALIA  VILLARROEL CAMACHO  ", Email="anditavillarroel99@gmail.com"}
            };
        }
    }
}
