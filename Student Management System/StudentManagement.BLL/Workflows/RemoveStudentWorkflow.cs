﻿using StudentManagement.BLL.Data;
using StudentManagement.BLL.Helpers;
using StudentManagement.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Workflows
{
    public class RemoveStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove Student");
            ConsoleIO.PrintStudentListHeader();

            StudentRepository repo = new StudentRepository(Settings.Filepath);
            List<Student> students = repo.List();

            ConsoleIO.PrintPickListOfStudents(students);
            Console.WriteLine();

            int index = ConsoleIO.GetStudentIndexFromUser("Which student would you like to delete", students.Count());
            index--;

            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to remove {students[index].FirstName} {students[index].LastName}");

            if (answer == "Y")
            {
                repo.Delete(index);
                Console.WriteLine("Student Removed");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Remove Cancelled");
                Console.ReadKey();
            }
        }
    }
}
