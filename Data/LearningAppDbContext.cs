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