﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211123011402_Schedules")]
    partial class Schedules
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Data.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresss")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Document")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FullName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.MedicalHistory", b =>
                {
                    b.Property<Guid>("Expedient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MotiveQuote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Recipe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Expedient");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalHistories");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Nurse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresss")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Document")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FullName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresss")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Document")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FullName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Quote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicalHistoryExpedient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NurseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryExpedient");

                    b.HasIndex("NurseId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuoteByhour")
                        .HasColumnType("int");

                    b.Property<int>("QuoteTotal")
                        .HasColumnType("int");

                    b.Property<Guid?>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.MedicalHistory", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.Doctor", "Doctor")
                        .WithMany("MedicalHistories")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Infrastructure.Data.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Quote", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.MedicalHistory", "MedicalHistory")
                        .WithMany("Quotes")
                        .HasForeignKey("MedicalHistoryExpedient");

                    b.HasOne("Infrastructure.Data.Entities.Nurse", "Nurse")
                        .WithMany("Quotes")
                        .HasForeignKey("NurseId");

                    b.HasOne("Infrastructure.Data.Entities.Reservation", "Reservation")
                        .WithMany("Quotes")
                        .HasForeignKey("ReservationId");

                    b.Navigation("MedicalHistory");

                    b.Navigation("Nurse");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Reservation", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.Doctor", "Doctor")
                        .WithMany("Reservations")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Infrastructure.Data.Entities.Schedule", "Schedule")
                        .WithMany("Reservations")
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Doctor");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Doctor", b =>
                {
                    b.Navigation("MedicalHistories");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.MedicalHistory", b =>
                {
                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Nurse", b =>
                {
                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Reservation", b =>
                {
                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Schedule", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
