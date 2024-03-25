using System;
using System.Collections.Generic;

namespace GestioneEventi.Models;

public partial class Risorse
{
    private static Risorse? instance;

    public static Risorse getInstance()
    {
        if(instance == null)
            instance = new Risorse();
        return instance;
    }
    public int IdRisorse { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Costo { get; set; }

    public int Quantità { get; set; }

    public string Fornitore { get; set; } = null!;
}
