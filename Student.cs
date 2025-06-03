using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        //public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
    }
}
