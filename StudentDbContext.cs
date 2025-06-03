using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Models;
using System.Collections.Generic;

namespace StudentManagementApp.Data
{
    public class StudentDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=StudentDb;User Id=postgres;Port=5432;Password=Sunil@57;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("students");
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
        public DbSet<Student> Student { get; set; }
    }
}
