using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementWebsite.Models
{
    public class StudentRepository
    {
        static Student _student;

        public static Student GetStudent()
        {
            return _student;
        }

        public static void SetStudent(Student newStudent)
        {
            _student = newStudent;
        }

        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student{FirstName = "Kevin", LastName="King", Major="Business", GPA = 3.5M},
                new Student{FirstName = "John", LastName="Smith", Major="Computer Science", GPA = 3.0M},
                new Student{FirstName = "Carrie", LastName="Cooler", Major="Finance", GPA = 3.7M}
            };
        }
    }
}