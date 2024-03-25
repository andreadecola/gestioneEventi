using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestioneEventi.Models;

public partial class GestioneEventiContext : DbContext
{
    public GestioneEventiContext()
    {
    }

    public GestioneEventiContext(DbContextOptions<GestioneEventiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Eventi> Eventis { get; set; }

    public virtual DbSet<Partecipanti> Partecipantis { get; set; }

    public virtual DbSet<Risorse> Risorses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = ACADEMY2022-19\\SQLEXPRESS;Database=GestioneEventi;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eventi>(entity =>
        {
            entity.HasKey(e => e.IdEventi).HasName("PK__Eventi__C8DC7BD0FA6C4C76");

            entity.ToTable("Eventi");

            entity.Property(e => e.IdEventi).HasColumnName("idEventi");
            entity.Property(e => e.CapienzaMax).HasColumnName("capienzaMax");
            entity.Property(e => e.Dataevento)
                .HasColumnType("datetime")
                .HasColumnName("dataevento");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descrizione");
            entity.Property(e => e.Luogo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("luogo");
            entity.Property(e => e.NomeEvento)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nomeEvento");

            entity.HasMany(d => d.PartecipantiRifs).WithMany(p => p.EventiRifs)
                .UsingEntity<Dictionary<string, object>>(
                    "PartecipanteEventi",
                    r => r.HasOne<Partecipanti>().WithMany()
                        .HasForeignKey("PartecipantiRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Partecipa__parte__3E52440B"),
                    l => l.HasOne<Eventi>().WithMany()
                        .HasForeignKey("EventiRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Partecipa__event__3F466844"),
                    j =>
                    {
                        j.HasKey("EventiRif", "PartecipantiRif").HasName("PK__Partecip__271B2A9E94D79B15");
                        j.ToTable("Partecipante_Eventi");
                        j.IndexerProperty<int>("EventiRif").HasColumnName("eventiRIF");
                        j.IndexerProperty<int>("PartecipantiRif").HasColumnName("partecipantiRIF");
                    });
        });

        modelBuilder.Entity<Partecipanti>(entity =>
        {
            entity.HasKey(e => e.IdPartecipanti).HasName("PK__Partecip__CC455B55BBF0DF3B");

            entity.ToTable("Partecipanti");

            entity.HasIndex(e => e.Contatto, "UQ__Partecip__83808B60525292B8").IsUnique();

            entity.Property(e => e.IdPartecipanti).HasColumnName("idPartecipanti");
            entity.Property(e => e.CodFis)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("codFis");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Contatto)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contatto");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Risorse>(entity =>
        {
            entity.HasKey(e => e.IdRisorse).HasName("PK__Risorse__452CFB402B5EDB63");

            entity.ToTable("Risorse");

            entity.Property(e => e.IdRisorse).HasColumnName("idRisorse");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Fornitore)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fornitore");
            entity.Property(e => e.Quantità).HasColumnName("quantità");
            entity.Property(e => e.Tipo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
