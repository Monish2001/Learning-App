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
    [Migration("20211008121701_AddTrackQuestionsToDatabase")]
    partial class AddTrackQuestionsToDatabase
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

            modelBuilder.Entity("Learning_App.Models.Chapters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("logo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Chapters");
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

            modelBuilder.Entity("Learning_App.Models.Contents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("ContentData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("Learning_App.Models.Excercises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<int>("MaxCredit")
                        .HasColumnType("int");

                    b.Property<int>("NoOfQuestions")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeLimit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Excercises");
                });

            modelBuilder.Entity("Learning_App.Models.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Notes");
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

            modelBuilder.Entity("Learning_App.Models.Options", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("OptionValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Learning_App.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExcerciseId")
                        .HasColumnType("int");

                    b.Property<int>("MaxCredit")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeLimit")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.ToTable("Questions");
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

            modelBuilder.Entity("Learning_App.Models.TrackExcercises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExcerciseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.HasIndex("StudentId");

                    b.ToTable("TrackExcercises");
                });

            modelBuilder.Entity("Learning_App.Models.TrackPdf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsViewed")
                        .HasColumnType("bit");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("StudentId");

                    b.ToTable("TrackPdf");
                });

            modelBuilder.Entity("Learning_App.Models.TrackVideos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CompletedDuration")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TotalDuration")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("StudentId");

                    b.ToTable("TrackVideos");
                });

            modelBuilder.Entity("Learning_App.Models.Votes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVoted")
                        .HasColumnType("bit");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Learning_App.Models.Chapters", b =>
                {
                    b.HasOne("Learning_App.Models.Subjects", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Learning_App.Models.Classes", b =>
                {
                    b.HasOne("Learning_App.Models.Boards", "Board")
                        .WithMany("Class")
                        .HasForeignKey("BoardId");

                    b.Navigation("Board");
                });

            modelBuilder.Entity("Learning_App.Models.Contents", b =>
                {
                    b.HasOne("Learning_App.Models.Chapters", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId");

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("Learning_App.Models.Excercises", b =>
                {
                    b.HasOne("Learning_App.Models.Chapters", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId");

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("Learning_App.Models.Notes", b =>
                {
                    b.HasOne("Learning_App.Models.Contents", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("Learning_App.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Content");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Learning_App.Models.Options", b =>
                {
                    b.HasOne("Learning_App.Models.Questions", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Learning_App.Models.Questions", b =>
                {
                    b.HasOne("Learning_App.Models.Excercises", "Excercise")
                        .WithMany("Question")
                        .HasForeignKey("ExcerciseId");

                    b.Navigation("Excercise");
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

            modelBuilder.Entity("Learning_App.Models.TrackExcercises", b =>
                {
                    b.HasOne("Learning_App.Models.Excercises", "Excercise")
                        .WithMany()
                        .HasForeignKey("ExcerciseId");

                    b.HasOne("Learning_App.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Excercise");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Learning_App.Models.TrackPdf", b =>
                {
                    b.HasOne("Learning_App.Models.Contents", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("Learning_App.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Content");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Learning_App.Models.TrackVideos", b =>
                {
                    b.HasOne("Learning_App.Models.Contents", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("Learning_App.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Content");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Learning_App.Models.Votes", b =>
                {
                    b.HasOne("Learning_App.Models.Contents", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("Learning_App.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Content");

                    b.Navigation("Student");
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

            modelBuilder.Entity("Learning_App.Models.Excercises", b =>
                {
                    b.Navigation("Question");
                });
#pragma warning restore 612, 618
        }
    }
}
