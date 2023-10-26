using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Model;

public partial class PersonContext : DbContext
{
    public PersonContext()
    {
    }

    public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-38PQ96J;Database=Person;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1FD184E30");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.EmployeeRoleId).HasName("PK__Employee__34618686CC1EDC06");

            entity.ToTable("EmployeeRole");

            entity.Property(e => e.EmployeeRoleId).HasColumnName("EmployeeRoleID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__EmployeeR__Emplo__2CF2ADDF");

            entity.HasOne(d => d.Role).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__EmployeeR__RoleI__2DE6D218");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__Form__FB05B7DD42791269");

            entity.ToTable("Form");

            entity.Property(e => e.FormId).ValueGeneratedNever();
            entity.Property(e => e.Datelindja).HasColumnType("date");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Emri)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GjendjaMartesore)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gjinia)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Ipunesuar).HasColumnName("IPunesuar");
            entity.Property(e => e.Mbiemri)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Vendlindja)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Forms)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Form__EmployeeID__282DF8C2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A6C9EA0D2");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
