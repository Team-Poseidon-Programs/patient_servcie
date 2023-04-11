using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Layer.Entities;

public partial class PatientInfoDbContext : DbContext
{
    public PatientInfoDbContext()
    {
    }

    public PatientInfoDbContext(DbContextOptions<PatientInfoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<VisitDetail> VisitDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=tcp:poseidonserver.database.windows.net,1433;initial catalog=Patient_Info_DB;persist security info=false;user id=poseidon;password=Program@123;multipleactiveresultsets=false;encrypt=true;trustservercertificate=false;connection timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("patient_id_pk");

            entity.ToTable("patient");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.ContactNumber)
                .IsUnicode(false)
                .HasColumnName("contact_number");
            entity.Property(e => e.Dob)
                .IsUnicode(false)
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prescription_id_pk");

            entity.ToTable("prescription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dosage)
                .IsUnicode(false)
                .HasColumnName("dosage");
            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.PrescriptionName)
                .IsUnicode(false)
                .HasColumnName("prescription_name");
            entity.Property(e => e.VisitDetailsId).HasColumnName("visit_details_id");

            entity.HasOne(d => d.VisitDetails).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.VisitDetailsId)
                .HasConstraintName("p_visit_id_fk");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("test_id_pk");

            entity.ToTable("test");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Result)
                .IsUnicode(false)
                .HasColumnName("result");
            entity.Property(e => e.TestName)
                .IsUnicode(false)
                .HasColumnName("test_name");
            entity.Property(e => e.VisitDetailsId).HasColumnName("visit_details_id");

            entity.HasOne(d => d.VisitDetails).WithMany(p => p.Tests)
                .HasForeignKey(d => d.VisitDetailsId)
                .HasConstraintName("visit_id_fk");
        });

        modelBuilder.Entity<VisitDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visit_id_pk");

            entity.ToTable("visit_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.BloodGroup)
                .IsUnicode(false)
                .HasColumnName("blood_group");
            entity.Property(e => e.BloodPressureDiastolic).HasColumnName("blood_pressure_diastolic");
            entity.Property(e => e.BloodPressureSystolic).HasColumnName("blood_pressure_systolic");
            entity.Property(e => e.BodyTemperature).HasColumnName("body_temperature");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.KeyNotes)
                .IsUnicode(false)
                .HasColumnName("key_notes");
            entity.Property(e => e.NurseEmail)
                .IsUnicode(false)
                .HasColumnName("nurse_email");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PhysicianEmail)
                .IsUnicode(false)
                .HasColumnName("physician_email");
            entity.Property(e => e.RespirationRate).HasColumnName("respiration_rate");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Patient).WithMany(p => p.VisitDetails)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("patient_id_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
