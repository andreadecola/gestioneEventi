using System;
using System.Collections.Generic;

namespace GestioneEventi.Models;


public partial class Eventi
{
    private static Eventi? instance;

    public static Eventi getInstance()
    {
        if (instance == null)
            instance = new Eventi();
        return instance;
    }
    public int IdEventi { get; set; }

    public string NomeEvento { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public DateTime Dataevento { get; set; }

    public string Luogo { get; set; } = null!;

    public int CapienzaMax { get; set; }

    public virtual ICollection<Partecipanti> PartecipantiRifs { get; set; } = new List<Partecipanti>();

    public static implicit operator Eventi(Eventi v)
    {
        throw new NotImplementedException();
    }
}
