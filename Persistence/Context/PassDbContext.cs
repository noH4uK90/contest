using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Context;

public partial class PassDbContext : DbContext
{
    public PassDbContext()
    {
    }

    public PassDbContext(DbContextOptions<PassDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserVisit> UserVisits { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<VisitInfo> VisitInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Database");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.IdBranch);

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartment);

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee);

            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.Birthsday).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.Organization).HasMaxLength(50);
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(53)
                .IsUnicode(false);
            entity.Property(e => e.PassportSeries)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
        });

        modelBuilder.Entity<UserVisit>(entity =>
        {
            entity.HasKey(e => new { e.IdVisit, e.IdUser });

            entity.Property(e => e.GroupName).HasMaxLength(255);
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.IdVisit);

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.IdVisitInfo).HasMaxLength(255);
        });

        modelBuilder.Entity<VisitInfo>(entity =>
        {
            entity.HasKey(e => e.IdVisitInfo);

            entity.ToTable("VisitInfo");

            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.Purpose).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
