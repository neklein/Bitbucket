using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Helpers
{
    public class ConsoleIO
    {
        public static void PrintListErrorMessage(ListStudentResponse response)
        {
            Console.WriteLine("An error occured loading the studnet list: ");
            Console.Write(response.Message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
    }
}
