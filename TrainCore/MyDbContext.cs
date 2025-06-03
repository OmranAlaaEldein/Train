using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml;
using DomainTrain.model;
using Microsoft.EntityFrameworkCore;

namespace DomainTrain
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activeuser> Activeusers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Courseregistration> Courseregistrations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Suggestions> Suggestions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.work_day)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<DayOfWeek>>(v, (JsonSerializerOptions)null));
        }

    }
}
