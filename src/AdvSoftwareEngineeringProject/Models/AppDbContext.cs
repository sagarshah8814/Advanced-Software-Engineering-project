using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvSoftwareEngineeringProject.Models
{
    //DbContext class for communicating with database
    public class AppDbContext : IdentityDbContext<Student>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }
        //List of DbSets properties for model classes to get and set data from database 
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<Assignment> Assignment { get; set; }

        /*Many to many relationship is not supported by Entity Framework Core, so
         we have to make three tables for generating a relationship between two tables.
         Here we have mannualy assigned the foreign keys for course,student and coursestudent model classes
         */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating( modelBuilder);
            
            modelBuilder.Entity<CourseStudent>()
                .HasKey(t => new { t.CourseId, t.StudentId });

            modelBuilder.Entity<CourseStudent>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseStudents)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(pt => pt.Student)
                .WithMany(t => t.CourseStudents)
                .HasForeignKey(pt => pt.StudentId);
        }
    }
}
