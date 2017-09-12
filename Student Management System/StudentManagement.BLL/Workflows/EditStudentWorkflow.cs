using StudentManagement.BLL.Data;
using StudentManagement.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Workflows
{
    public class EditStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit Student GPA");

            StudentRepository reo = new StudentRepository(Settings.FilePath);
            ListStudentResponse response = repo.List();

            if (!response.Success)
            {
                ConsoleIO.PrintListErrorMessage(response);
                return;
            }
            List<Student> students = response.Students;
        }
    }
}
