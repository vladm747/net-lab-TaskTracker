using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using TaskTrackerDAL.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaskTrackerDAL.Context
{
    public class TaskTrackerContext: IdentityDbContext<User>
    {
        public DbSet<ToDo> ToDos { get; set; }
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options)
          : base(options)
        {
            /*Database.EnsureDeleted();*/

            Database.EnsureCreated();
        }
        public TaskTrackerContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
               .HasMany(c => c.ToDos)
               .WithOne(e => e.User)
               .OnDelete(DeleteBehavior.SetNull);
            base.OnModelCreating(builder);
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TaskTrackerDB;Trusted_Connection=True;");
        }
    }
}
