using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementApp.Models;

namespace StudentManagementApp.Data
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.LastName).HasMaxLength(50);
            builder.Property(s => s.Email).HasMaxLength(100);
            builder.Property(s => s.Department).HasMaxLength(50);
        }
    }
}
