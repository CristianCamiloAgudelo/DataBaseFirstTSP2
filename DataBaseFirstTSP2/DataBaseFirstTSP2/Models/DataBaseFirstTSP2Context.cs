using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataBaseFirstTSP2.Models
{
    public partial class DataBaseFirstTSP2Context : DbContext
    {
        public DataBaseFirstTSP2Context()
        {
        }

        public DataBaseFirstTSP2Context(DbContextOptions<DataBaseFirstTSP2Context> options)
            : base(options)

        {
        }

        public virtual DbSet<EquipoDesarrollo> EquipoDesarrollo { get; set; }
        public virtual DbSet<PlanGrupal> PlanGrupal { get; set; }
        public virtual DbSet<PlanIndividual> PlanIndividual { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=DataBaseFirstTSP2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipoDesarrollo>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<PlanGrupal>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.EquipoDesarrollo)
                    .WithMany(p => p.PlanGrupal)
                    .HasForeignKey(d => d.EquipoDesarrolloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanGrupa__Equip__286302EC");
            });

            modelBuilder.Entity<PlanIndividual>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PlanIndividual)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanIndiv__Usuar__2B3F6F97");
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.PlanGrupal)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.PlanGrupalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tarea__PlanGrupa__2E1BDC42");

                entity.HasOne(d => d.PlanIndividual)
                    .WithMany(p => p.Tarea)
                    .HasForeignKey(d => d.PlanIndividualId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tarea__PlanIndiv__2F10007B");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Rol).HasMaxLength(50);

                entity.Property(e => e.Universidad).HasMaxLength(50);

                entity.HasOne(d => d.EquipoDesarrollo)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.EquipoDesarrolloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__EquipoD__25869641");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
