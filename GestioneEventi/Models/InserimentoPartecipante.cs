using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEventi.Models
{
   
    internal class InserimentoPartecipante
    {
        public void addPartecipante()
        {
            using(var par = new GestioneEventiContext())

            {
                try
                {
                    Partecipanti partecipante = new Partecipanti()
                    {
                        Nome = "Andrea",
                        Cognome = " De lellis",
                        CodFis = "23ANDLLE510FH501",
                        Contatto = "34903895678",
                        IdPartecipanti = 1
                        




                    };

                }
                   
                {
                    Console.WriteLine("Partecipante non inserito");
                }
        }
        
        


    }
   
}
