﻿// <auto-generated />
using System;
using Learning_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Learning_App.Migrations
{
    [DbContext(typeof(LearningAppDbContext))]
    [Migration("20211008104329_AddTrackExcercisesToDatabase")]
    partial class AddTrackExcercisesToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Learning_App.Models.Boards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Learning_App.Models.Classes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoardId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Learning_App.Models.OTP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("GeneratedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Otp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OTP");
                });

            modelBuilder.Entity("Learning_App.Models.StudentEnrollments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoardId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("ClassId");

                    b.ToTable("StudentEnrollments");
                });

            modelBuilder.Entity("Learning_App.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OtpId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentEnrollmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OtpId");

                    b.HasIndex("StudentEnrollmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Learning_App.Models.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("SubName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Learning_App.Models.Classes", b =>
                {
                    b.HasOne("Learning_App.Models.Boards", "Board")
                        .WithMany("Class")
                        .HasForeignKey("BoardId");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Learning_App.Models.StudentEnrollments", b =>
                {
                    b.HasOne("Learning_App.Models.Boards", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId");

                    b.HasOne("Learning_App.Models.Classes", "Class")
                        .WithMany("StudentEnrollment")
                        .HasForeignKey("ClassId");

                    b.Navigation("Board");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Learning_App.Models.Students", b =>
                {
                    b.HasOne("Learning_App.Models.OTP", "Otp")
                        .WithMany()
                        .HasForeignKey("OtpId");

                    b.HasOne("Learning_App.Models.StudentEnrollments", "StudentEnrollment")
                        .WithMany()
                        .HasForeignKey("StudentEnrollmentId");

                    b.Navigation("Otp");

                    b.Navigation("StudentEnrollment");
                });

            modelBuilder.Entity("Learning_App.Models.Subjects", b =>
                {
                    b.HasOne("Learning_App.Models.Classes", "Class")
                        .WithMany("Subject")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Learning_App.Models.Boards", b =>
                {
                    b.Navigation("Class");
                });

            modelBuilder.Entity("Learning_App.Models.Classes", b =>
                {
                    b.Navigation("StudentEnrollment");

                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
