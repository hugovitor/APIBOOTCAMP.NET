using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIBOOTCAMP.NET.Models;

#nullable disable

namespace APIBOOTCAMP.NET.BootCampContext
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SMT182152\\SQLEXPRESS;Database=APIBOOTCAMP.NET;Integrated Security=SSPI;Persist Security Info=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.Property(e => e.VeiculoId).HasColumnName("veiculoId");

                entity.Property(e => e.Ano)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ano");

                entity.Property(e => e.Combustivel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("combustivel");

                entity.Property(e => e.Cor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cor");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Placa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("placa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
