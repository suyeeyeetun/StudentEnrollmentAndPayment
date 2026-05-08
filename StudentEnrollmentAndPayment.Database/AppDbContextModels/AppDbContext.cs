using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentEnrollmentAndPayment.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblPersonalInformation> TblPersonalInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=StudentInfoDb;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblPersonalInformation>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("Tbl_PersonalInformation");

            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fatherName");
            entity.Property(e => e.FatherPhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fatherPhoneNumber");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.MotherName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("motherName");
            entity.Property(e => e.MotherPhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("motherPhoneNumber");
            entity.Property(e => e.Nationality)
                .HasMaxLength(50)
                .HasColumnName("nationality");
            entity.Property(e => e.Nrc)
                .HasMaxLength(50)
                .HasColumnName("NRC");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Profile).HasColumnName("profile");
            entity.Property(e => e.Religion)
                .HasMaxLength(50)
                .HasColumnName("religion");
            entity.Property(e => e.RollNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
