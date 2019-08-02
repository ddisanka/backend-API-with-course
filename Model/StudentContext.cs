using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentapp.Model
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> tblstudents { get; set; }
        public DbSet<Lecturer> tbllecturers { get; set; }
        public DbSet<Course> tblcourses {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
