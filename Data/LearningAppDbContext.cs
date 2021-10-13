// using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Learning_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_App.Data
{
    public class LearningAppDbContext : DbContext
    {
        public LearningAppDbContext(DbContextOptions<LearningAppDbContext> options) : base(options)
        {

        }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentEnrollments> StudentEnrollments { get; set; }
        public DbSet<Boards> Boards { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<OTP> OTP { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Chapters> Chapters { get; set; }
        public DbSet<Contents> Contents { get; set; }
        public DbSet<TrackVideos> TrackVideos { get; set; }
        public DbSet<TrackPdf> TrackPdf { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Votes> Votes { get; set; }
        public DbSet<Excercises> Excercises { get; set; }
        public DbSet<TrackExcercises> TrackExcercises { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<TrackQuestions> TrackQuestions { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
    }
}

// using Microsoft.EntityFrameworkCore;

// namespace Learning_App.Data {
//     public class LearningAppDbContext : DbContext {
//         public LearningAppDbContext (DbContextOptions<LearningAppDbContext> options) : base (options) { }
//         public DbSet<Students> Students { get; set; }
//         public DbSet<StudentEnrollments> StudentEnrollments { get; set; }
//         public DbSet<Boards> Boards { get; set; }
//         public DbSet<Classes> Classes { get; set; }
//     }
// }