using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEventi.Models
{
    internal class InserimentoEvento
    {
        public void addEvento()
        {
            using(var evento = new GestioneEventiContext())
            {
                try
                {
                    Eventi eve = new Eventi()
                    {
                        CapienzaMax = 100,
                        Descrizione = "disco bar",
                        Dataevento = new DateTime(2024, 04, 22),
                        Luogo = "Roma",
                        NomeEvento = "Spazio 900",
                        IdEventi = 1


                    };
                    
                      
                                            
                }
            }
        }
    }
}
