﻿namespace TheThreeOwlsWebApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TheThreeOwlsWebApp.Data.Models;

    public class ThreeOwlsDbContext : IdentityDbContext
    {
        public ThreeOwlsDbContext(DbContextOptions<ThreeOwlsDbContext> options)
            : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<IntroComment> IntroComments { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<CourseCategory> Categories{ get; set; }

        public DbSet<StudyHall> StudyHalls{ get; set; }

        public DbSet<School> Schools{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database=TTOwls;Trusted_Connection=True;Integrated Security=True;");
            }
        }
    }
}
