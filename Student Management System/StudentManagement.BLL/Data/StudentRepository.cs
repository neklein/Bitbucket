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

        private string _filePath = @"C:\repos\Bitbucket\Data\SystemIO\Student.txt";

        public StudentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public ListStudentResponses List()
        {
            ListStudentResponses response = new ListStudentResponses();
            response.Success = true;

            response.Students = new List<Student>();

            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;

                    //Could put "try" in the loop to just skip the bad students
                    //however, we want to know if something goes wrong
                    while ((line = sr.ReadLine()) != null)
                    {
                        Student newStudent = new Student();

                        string[] columns = line.Split(',');

                        newStudent.FirstName = columns[0];
                        newStudent.LastName = columns[1];
                        newStudent.Major = columns[2];
                        newStudent.GPA = decimal.Parse(columns[3]);

                        response.Students.Add(newStudent);
                    }

                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public void Add(Student student)
        {
            using(StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCsvForStudent(student);

                sw.WriteLine(line);
            }
        }

        public void Edit(Student student, int index)
        {
            var response = List();

            students[index] = student;

            CreateStudentFile(students);

        }

        public void Delete(int index)
        {
            var response = List();
            students.RemoveAt(index);

            CreateStudentFile(students);
        }

        private string CreateCsvForStudent(Student student)
        {
            return string.Format("{0},{1},{2},{3}", student.FirstName, 
                student.LastName, student.Major, student.GPA.ToString());
        }
        private void CreateStudentFile(List<Student> students)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("FirstName,LastName,Major,GPA");
                foreach(var student in students)
                {
                    sr.WriteLine(CreateCsvForStudent(student));
                }
            }
        }
    }
}
