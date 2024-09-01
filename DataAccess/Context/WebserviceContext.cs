using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Context
{
    public partial class WebserviceContext : DbContext
    {
        public WebserviceContext()
        {
        }

        public WebserviceContext(DbContextOptions<WebserviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Materia> Materia { get; set; } = null!;
        public virtual DbSet<Nota> Notas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notas__Estudiant__29572725");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.MateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notas__Semestre__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
