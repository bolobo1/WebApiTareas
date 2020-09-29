using System;
using APITareas.Models.MisModelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APITareas.Models.Database
{
    public partial class PRUEBASContext : DbContext
    {
        public PRUEBASContext()
        {
        }

        public PRUEBASContext(DbContextOptions<PRUEBASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Tareas> Tareas { get; set; }
        public virtual DbSet<SPTareasListarCLS>  SPTareasListar { get; set; }
        public virtual DbSet<SPTareaCreateCLS> SPTareaCreate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LEON-PC;Database=PRUEBAS; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.ToTable("COLABORADOR");

                entity.Property(e => e.ColaboradorId).HasColumnName("COLABORADOR_ID");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tareas>(entity =>
            {
                entity.ToTable("TAREAS");

                entity.Property(e => e.TareasId).HasColumnName("TAREAS_ID");

                entity.Property(e => e.TareaFechaFin)
                    .HasColumnName("TAREA_FECHA_FIN")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TareasColaborador).HasColumnName("TAREAS_COLABORADOR");

                entity.Property(e => e.TareasDescripcion)
                    .HasColumnName("TAREAS_DESCRIPCION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TareasEstado)
                    .HasColumnName("TAREAS_ESTADO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TareasFechaInicio)
                    .HasColumnName("TAREAS_FECHA_INICIO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TareasNotas)
                    .HasColumnName("TAREAS_NOTAS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TareasPrioridad)
                    .HasColumnName("TAREAS_PRIORIDAD")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.TareasColaboradorNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.TareasColaborador)
                    .HasConstraintName("FK__TAREAS__TAREAS_C__1273C1CD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
