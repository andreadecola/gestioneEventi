using System;
using System.Collections.Generic;

namespace GestioneEventi.Models;

public partial class Partecipanti
{
    private static Partecipanti? instance;

    public static Partecipanti getInstance()
    {
        if (instance == null)
            instance = new Partecipanti();
        return instance;
    }
    public int IdPartecipanti { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string CodFis { get; set; } = null!;

    public string Contatto { get; set; } = null!;

    public virtual ICollection<Eventi> EventiRifs { get; set; } = new List<Eventi>();

    public static implicit operator Partecipanti(Partecipanti v)
    {
        throw new NotImplementedException();
    }
}
