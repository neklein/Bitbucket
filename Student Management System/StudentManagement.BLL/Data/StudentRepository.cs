using StudentManagement.BLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Data
{
    public class StudentRepository
    {
        //list, add, edit, delete
        //C:Data\SystemIO\Data

        private string _filePath;

        public StudentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Student> List()
        {
            List<Student> students = new List<Student>();

            using(StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Student newStudent = new Student();

                    string[] columns = line.Split(',');

                    newStudent.FirstName = columns[0];
                    newStudent.LastName = columns[1];
                    newStudent.Major = columns[2];
                    newStudent.GPA = decimal.Parse(columns[3]);

                    students.Add(newStudent);
                }
            }

            return students;
        }

        public void Add(Student student)
        {
            throw new NotImplementedException();
        }

        public void Edit(Student student, int index)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }
    }
}
