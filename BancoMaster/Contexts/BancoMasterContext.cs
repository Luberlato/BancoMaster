using System;
using System.Collections.Generic;
using BancoMaster.Domains;
using Microsoft.EntityFrameworkCore;

namespace BancoMaster.Contexts;

public partial class BancoMasterContext : DbContext
{
    public BancoMasterContext()
    {
    }

    public BancoMasterContext(DbContextOptions<BancoMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conta> Conta { get; set; }

    public virtual DbSet<Transacao> Transacao { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GS4LSO7;Database=BancoMaster;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.HasKey(e => e.ContaId).HasName("PK__Conta__F7CF1DF4E3106951");

            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Conta)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Conta__UsuarioId__3B75D760");
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(e => e.TransacaoId).HasName("PK__Transaca__55823530E920A73F");

            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Enviador).WithMany(p => p.TransacaoEnviador)
                .HasForeignKey(d => d.EnviadorId)
                .HasConstraintName("FK__Transacao__Envia__3E52440B");

            entity.HasOne(d => d.Repecetor).WithMany(p => p.TransacaoRepecetor)
                .HasForeignKey(d => d.RepecetorId)
                .HasConstraintName("FK__Transacao__Repec__3F466844");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B8D19A5A30");

            entity.HasIndex(e => e.Nome, "UQ__Usuario__7D8FE3B278854A58").IsUnique();

            entity.HasIndex(e => e.CPF, "UQ__Usuario__C1F897317B9D2C95").IsUnique();

            entity.Property(e => e.CPF).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nome).HasMaxLength(200);
            entity.Property(e => e.Senha).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
