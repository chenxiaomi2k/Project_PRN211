using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PasswordLibrary.DataAccess;

public partial class ProjectPrn211Context : DbContext
{
    public ProjectPrn211Context()
    {
    }

    public ProjectPrn211Context(DbContextOptions<ProjectPrn211Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Password> Passwords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Project"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Password__3214EC07B00F80A4");

            entity.ToTable("Password");

            entity.Property(e => e.Category).HasMaxLength(20);
            entity.Property(e => e.Note).HasMaxLength(200);
            entity.Property(e => e.SavedPassword)
                .HasMaxLength(100)
                .HasColumnName("Saved_Password");
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.Website).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Passwords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Password__UserId__3A81B327");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07FAC65C16");

            entity.ToTable("User");

            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
