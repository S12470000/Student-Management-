using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;
using StudentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Services
{
    public class StudentService
    {
        private readonly StudentDbContext _context;

        public StudentService()
        {
            _context = new StudentDbContext();
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName))
            {
                Console.WriteLine("First Name is required.");
                return;
            }

            _context.Student.Add(student);
            _context.SaveChanges();
            Console.WriteLine("Student added successfully.\n");
        }



        public void ViewAllStudents()
        {
            var students = _context.Student.ToList();
            Console.WriteLine("All Students:");
            foreach (var s in students)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.FirstName} {s.LastName}, " +
                    //$"DOB: {s.DateOfBirth.ToShortDateString()}, " +
                    $"Email: {s.Email}, Dept: {s.Department}");
            }
        }

        public void UpdateStudent(int id)
        {
            var student = _context.Student.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Enter new First Name: ");
                var firstName = Console.ReadLine();
                student.FirstName = firstName ?? string.Empty; // Fix for CS8601

                Console.Write("Enter new Last Name: ");
                var lastName = Console.ReadLine();
                student.LastName = lastName; // Nullable property, no change needed

                Console.Write("Enter new Email: ");
                var email = Console.ReadLine();
                student.Email = email; // Nullable property, no change needed

                //Console.Write("Enter new Department: ");
                //var department = Console.ReadLine();
                //student.Department = department; // Nullable property, no change needed

                _context.SaveChanges();
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Student.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void SearchByDepartment(string dept)
        {
            var students = _context.Student
                .Where(s => !string.IsNullOrWhiteSpace(s.Department) &&
                            s.Department != null &&
                            s.Department.Equals(dept, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found in this department.");
                return;
            }

            Console.WriteLine($"\nStudents in '{dept}' Department:");
            foreach (var s in students)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.FirstName} {s.LastName}, Email: {s.Email}");
            }
        }
    }
}
