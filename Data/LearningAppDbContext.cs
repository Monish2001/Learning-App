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
        public DbSet<LearningApp> LearningApp { get; set; }
    }
}