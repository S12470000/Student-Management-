//using StudentManagement.Models;
using StudentManagement.Services;
using StudentManagementApp.Models;
using System;

class Program
{
    static void Main()
    {
        var service = new StudentService();
        while (true)
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Search Students by Department");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var student = new Student();

                    Console.Write("First Name: ");
                    student.FirstName = ReadNonNullString();

                    Console.Write("Last Name: ");
                    student.LastName = ReadNullableString();

                    //Console.Write("Date of Birth (yyyy-mm-dd): ");
                    //student.DateOfBirth = ReadValidDate();

                    Console.Write("Email: ");
                    student.Email = ReadNullableString();

                    Console.Write("Department: ");
                    student.Department = ReadNullableString();

                    service.AddStudent(student);
                    break;

                case "2":
                    service.ViewAllStudents();
                    break;

                case "3":
                    Console.Write("Enter StudentId to update: ");
                    int updateId = ReadValidInt();
                    service.UpdateStudent(updateId);
                    break;

                case "4":
                    Console.Write("Enter StudentId to delete: ");
                    int deleteId = ReadValidInt();
                    service.DeleteStudent(deleteId);
                    break;

                case "5":
                    Console.Write("Enter Department to search: ");
                    string dept = ReadNonNullString();
                    service.SearchByDepartment(dept);
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static string ReadNonNullString()
    {
        string? input;
        do
        {
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                Console.Write("Input cannot be empty. Please enter again: ");
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    static string? ReadNullableString()
    {
        string? input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? null : input;
    }

    //static DateTime ReadValidDate()
    //{
    //    while (true)
    //    {
    //        string? input = Console.ReadLine();
    //        if (DateTime.TryParse(input, out var date))
    //            return date;
    //        Console.Write("Invalid date. Please enter again (yyyy-mm-dd): ");
    //    }
    //}

    static int ReadValidInt()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out var value))
                return value;
            Console.Write("Invalid number. Please enter again: ");
        }
    }
}
