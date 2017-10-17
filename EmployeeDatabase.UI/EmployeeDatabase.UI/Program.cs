using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDatabase.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectQuery selectQuery = new SelectQuery();
            selectQuery.GetEmployeeRates();

            Console.ReadKey();
        }
    }
}
