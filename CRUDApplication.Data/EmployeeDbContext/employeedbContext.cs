using System;
using CRUDApplication.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDApplication.Data.EmployeeDbContext
{
    public partial class employeedbContext : DbContext
    {
        public employeedbContext()
        {
        }

        public employeedbContext(DbContextOptions<employeedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=employeedb;user=root;password=Toor@123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.LocationId, "LocationId_idx");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(45);

                //entity.HasOne(d => d.Location)
                //    .WithMany(p => p.Departments)
                //    .HasForeignKey(d => d.LocationId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("LocationId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.DepartmentId, "DeptId_idx");

                entity.HasIndex(e => e.ManagerId, "ManagerId_idx");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Doj)
                    .HasColumnType("datetime")
                    .HasColumnName("DOJ");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(75);

                //entity.HasOne(d => d.Department)
                //    .WithMany(p => p.Employees)
                //    .HasForeignKey(d => d.DepartmentId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("DeptId");

                //entity.HasOne(d => d.Manager)
                //    .WithMany(p => p.InverseManager)
                //    .HasForeignKey(d => d.ManagerId)
                //    .HasConstraintName("ManagerId");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
