﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RPPP_WebApp.ViewModels;

namespace RPPP_WebApp.Models;

public partial class ProjektDbContext : DbContext
{
    public ProjektDbContext(DbContextOptions<ProjektDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dokumentacija> Dokumentacija { get; set; }
    public virtual DbSet<LogEntry> LogEntries { get; set; }

    public virtual DbSet<Kartica> Kartica { get; set; }

    public virtual DbSet<Osoba> Osoba { get; set; }

    public virtual DbSet<Partner> Partner { get; set; }

    public virtual DbSet<Posao> Posao { get; set; }

    public virtual DbSet<Projekt> Projekt { get; set; }

    public virtual DbSet<RadiNa> RadiNa { get; set; }

    public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<Transakcija> Transakcija { get; set; }

    public virtual DbSet<Uloga> Uloga { get; set; }

    public virtual DbSet<VrstaDok> VrstaDok { get; set; }

    public virtual DbSet<VrstaPosla> VrstaPosla { get; set; }

    public virtual DbSet<VrstaProjekta> VrstaProjekta { get; set; }

    public virtual DbSet<VrstaTransakcije> VrstaTransakcije { get; set; }

    public virtual DbSet<VrstaUloge> VrstaUloge { get; set; }

    public virtual DbSet<VrstaZah> VrstaZah { get; set; }

    public virtual DbSet<Zadatak> Zadatak { get; set; }

    public virtual DbSet<Zahtjev> Zahtjev { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dokumentacija>(entity =>
        {
            entity.HasKey(e => new { e.IdDok }).HasName("PK__dokument__2E8F180E81B94F3D");

            entity.Property(e => e.IdDok).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdProjektaNavigation).WithMany(p => p.Dokumentacija)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dokumenta__idPro__71D1E811");

            entity.HasOne(d => d.IdVrsteNavigation).WithMany(p => p.Dokumentacija)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dokumenta__idVrs__72C60C4A");
        });
        modelBuilder.Entity<LogEntry>(entity =>
        {
            entity.ToTable("LogTable");
            entity.HasKey(e => e.Id);

        });

        modelBuilder.Entity<Kartica>(entity =>
        {
            entity.HasKey(e => e.BrKartice).HasName("PK__kartica__04B983D06DCE607A");
        });

        modelBuilder.Entity<Osoba>(entity =>
        {
            entity.HasKey(e => e.IdOsoba).HasName("PK__osoba__EFB80D64C3FE9020");

            entity.Property(e => e.IdOsoba).ValueGeneratedNever();

            entity.HasOne(d => d.IdPartneraNavigation).WithMany(p => p.Osoba).HasConstraintName("FK__osoba__idPartner__5DCAEF64");

            entity.HasMany(d => d.IdPosla).WithMany(p => p.IdOsoba)
                .UsingEntity<Dictionary<string, object>>(
                    "Obavlja",
                    r => r.HasOne<Posao>().WithMany()
                        .HasForeignKey("IdPosla")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__obavlja__idPosla__04E4BC85"),
                    l => l.HasOne<Osoba>().WithMany()
                        .HasForeignKey("IdOsoba")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__obavlja__idOsoba__03F0984C"),
                    j =>
                    {
                        j.HasKey("IdOsoba", "IdPosla").HasName("PK__obavlja__D2E62D399D1A34E6");
                        j.ToTable("obavlja");
                        j.IndexerProperty<int>("IdOsoba").HasColumnName("idOsoba");
                        j.IndexerProperty<int>("IdPosla").HasColumnName("idPosla");
                    });
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.IdPartnera).HasName("PK__partner__B374D07B47B2EA0E");

            entity.HasMany(d => d.IdProjekta).WithMany(p => p.IdPartnera)
                .UsingEntity<Dictionary<string, object>>(
                    "ImaPartnera",
                    r => r.HasOne<Projekt>().WithMany()
                        .HasForeignKey("IdProjekta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__imaPartne__idPro__6383C8BA"),
                    l => l.HasOne<Partner>().WithMany()
                        .HasForeignKey("IdPartnera")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__imaPartne__idPar__628FA481"),
                    j =>
                    {
                        j.HasKey("IdPartnera", "IdProjekta").HasName("PK__imaPartn__A3BADC3B21577732");
                        j.ToTable("imaPartnera");
                        j.IndexerProperty<int>("IdPartnera").HasColumnName("idPartnera");
                        j.IndexerProperty<int>("IdProjekta").HasColumnName("idProjekta");
                    });
        });

        modelBuilder.Entity<Posao>(entity =>
        {
            entity.HasKey(e => e.IdPosla).HasName("PK__posao__D5E205D28962EF62");

            entity.HasOne(d => d.IdVrsteNavigation).WithMany(p => p.Posao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__posao__idVrste__75A278F5");
        });

        modelBuilder.Entity<Projekt>(entity =>
        {
            entity.HasKey(e => e.IdProjekta).HasName("PK__projekt__0CE0C40019F6A6E8");

            entity.HasOne(d => d.BrKarticeNavigation).WithMany(p => p.Projekt).HasConstraintName("FK_projekt_kartica");

            entity.HasOne(d => d.IdVrsteNavigation).WithMany(p => p.Projekt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__projekt__idVrste__59063A47");
        });

        modelBuilder.Entity<RadiNa>(entity =>
        {
            entity.HasKey(e => new { e.IdProjekta, e.IdOsoba, e.IdUloge }).HasName("PK__radiNa__9F95EE23196E8DDD");

            entity.HasOne(d => d.IdOsobaNavigation).WithMany(p => p.RadiNa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radiNa__idOsoba__7C4F7684");

            entity.HasOne(d => d.IdProjektaNavigation).WithMany(p => p.RadiNa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radiNa__idProjek__7B5B524B");

            entity.HasOne(d => d.IdUlogeNavigation).WithMany(p => p.RadiNa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radiNa__idUloge__7D439ABD");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatusa).HasName("PK__status__CFDD1DAA40166E3D");
        });

        modelBuilder.Entity<Transakcija>(entity =>
        {
            entity.HasKey(e => e.IdTrans).HasName("PK__transakc__0293237D68D47484");

            entity.HasOne(d => d.BrKarticeNavigation).WithMany(p => p.Transakcija)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_transakcija_kartica");

            entity.HasOne(d => d.IdVrsteNavigation).WithMany(p => p.Transakcija)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__transakci__idVrs__6754599E");
        });

        modelBuilder.Entity<Uloga>(entity =>
        {
            entity.HasKey(e => e.IdUloge).HasName("PK__uloga__8EAAF5CC1658941F");

            entity.HasOne(d => d.IdVrsteNavigation).WithMany(p => p.Uloga)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__uloga__idVrste__787EE5A0");
        });

        modelBuilder.Entity<VrstaDok>(entity =>
        {
            entity.HasKey(e => e.IdVrste).HasName("PK__vrstaDok__306017A9E7C51949");
        });

        modelBuilder.Entity<VrstaPosla>(entity =>
        {
            entity.HasKey(e => e.IdVrste).HasName("PK__vrstaPos__306017A98873300E");
        });

        modelBuilder.Entity<VrstaProjekta>(entity =>
        {
            entity.HasKey(e => e.IdVrste).HasName("PK__vrstaPro__306017A9686BB983");
        });

        modelBuilder.Entity<VrstaTransakcije>(entity =>
        {
            entity.HasKey(e => e.IdVrste).HasName("PK__vrstaTra__306017A9B837BEB1");
        });

        modelBuilder.Entity<VrstaUloge>(entity =>
        {
            entity.HasKey(e => e.IdVrste).HasName("PK__vrstaUlo__306017A91436C124");
        });

        modelBuilder.Entity<VrstaZah>(entity =>
        {
            entity.HasKey(e => e.IdVrste).HasName("PK__vrstaZah__306017A955BAB038");
        });

        modelBuilder.Entity<Zadatak>(entity =>
        {
            entity.HasKey(e => e.IdZadatka).HasName("PK__zadatak__05C4D6B1AC1AAF6E");

            entity.HasOne(d => d.IdOsobaNavigation).WithMany(p => p.Zadatak).HasConstraintName("FK__zadatak__idOsoba__6EF57B66");

            entity.HasOne(d => d.IdStatusaNavigation).WithMany(p => p.Zadatak)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__zadatak__idStatu__6E01572D");

            entity.HasOne(d => d.IdZahtjevaNavigation).WithMany(p => p.Zadatak)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__zadatak__idZahtj__6D0D32F4");
        });

        modelBuilder.Entity<Zahtjev>(entity =>
        {
            entity.HasKey(e => e.IdZahtjeva).HasName("PK__zahtjev__77C21E526E2308BB");

            entity.HasOne(d => d.IdProjektaNavigation).WithMany(p => p.Zahtjev).HasConstraintName("FK_zahtjev_projekt");

            entity.HasOne(d => d.IdVrsteNavigation).WithMany(p => p.Zahtjev).HasConstraintName("FK__zahtjev__idVrste__6A30C649");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}