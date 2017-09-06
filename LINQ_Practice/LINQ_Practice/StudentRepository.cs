using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Practice
{
    public class StudentRepository
    {
        public static List<Student> SelectAll()
        {
            return new List<Student>
            {
                new Student{ FirstName = "Joe", LastName = "Smith", Major = "Computer Science", GPA = 3.5M },
                new Student{ FirstName = "Mary", LastName = "Jones", Major = "Business", GPA = 3.0M },
                new Student{ FirstName = "Jane", LastName = "Doe", Major = "Computer Science", GPA = 4.0M },
                new Student{ FirstName = "Bobby", LastName = "Tables", Major = "English", GPA = 2.7M },
                new Student{ FirstName = "Rhonda", LastName = "Miller", Major = "English", GPA = 3.8M },
                new Student{ FirstName = "Karren", LastName = "Poole", Major = "Theater", GPA = 2.3M },
            };
        }
    }
}
