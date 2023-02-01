using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestApp.MVC.Data;

public partial class ManagementDbContext : DbContext
{
    public ManagementDbContext()
    {
    }

    public ManagementDbContext(DbContextOptions<ManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Oficina> Oficinas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=ManagementDb; Trusted_Connection=true;MultipleActiveResultSets=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC0792B4CF7D");

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Oficina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Oficinas__3214EC07894AE446");

            entity.HasIndex(e => e.Codigo, "UQ__Oficinas__06370DACD9B3E3DE").IsUnique();

            entity.Property(e => e.Calle).HasMaxLength(50);
            entity.Property(e => e.Codigo).HasMaxLength(5);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personas__3214EC07A67DE1E3");

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
