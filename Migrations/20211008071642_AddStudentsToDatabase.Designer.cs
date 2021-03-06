// <auto-generated />
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
    [Migration("20211008071642_AddStudentsToDatabase")]
    partial class AddStudentsToDatabase
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

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

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

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Learning_App.Models.Classes", b =>
                {
                    b.HasOne("Learning_App.Models.Boards", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Learning_App.Models.StudentEnrollments", b =>
                {
                    b.HasOne("Learning_App.Models.Boards", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId");

                    b.HasOne("Learning_App.Models.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Learning_App.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Board");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
