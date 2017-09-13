using StudentManagement.BLL.Helpers;
using StudentManagement.BLL.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.UI
{
    public class MainMenu
    {

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");

            Console.WriteLine(ConsoleIO.separatorBar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Edit Student GPA");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(ConsoleIO.separatorBar);
            Console.WriteLine("");
            Console.WriteLine("Enter choice: ");

        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListStudentWorkflow workflow = new ListStudentWorkflow();
                    workflow.Execute();
                    break;
                case "2":
                    AddStudentWorkflow addWorkFlow = new AddStudentWorkflow();
                    addWorkFlow.Execute();
                    break;
                case "3":
                    RemoveStudentWorkflow removeStudent = new RemoveStudentWorkflow();
                    removeStudent.Execute();
                    
                    break;
                case "4":
                    EditStudentWorkflow editWorkflow = new EditStudentWorkflow();
                    editWorkflow.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            return true;

        }

        public static void Show()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();

            }


        }
    }
}
