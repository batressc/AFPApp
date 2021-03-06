﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AFPApp.DataAccess.Model
{
    public partial class AFPAppDbContext : DbContext
    {
        public AFPAppDbContext()
        {
        }

        public AFPAppDbContext(DbContextOptions<AFPAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Afiliado> Afiliado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afiliado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bio)
                    .HasColumnName("bio")
                    .HasMaxLength(500);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}