using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeesMVC.Models
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees;

        static EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee{EmployeeID=1, FirstName="Jenny", LastName="Jones", PhoneNumber="888-888-8888", DepartmentId=1},
                new Employee{EmployeeID=2, FirstName="Bob", LastName="Ross", PhoneNumber="555-555-5555", DepartmentId=1},
                new Employee{EmployeeID=3, FirstName="Jane", LastName="Smith", PhoneNumber="111-111-1111", DepartmentId=3}
            };

        }

        public static void Add(Employee employee)
        {
            if (_employees.Any())
            {
                employee.EmployeeID = _employees.Max(e => e.EmployeeID) + 1;
            }
            else
            {
                employee.EmployeeID = 1;
            }
            _employees.Add(employee);

        }

        public static void Edit(Employee employee)
        {
            _employees.RemoveAll(e => e.EmployeeID == employee.EmployeeID);
            _employees.Add(employee);
        }

        public static void Delete(int employeeId)
        {
            _employees.RemoveAll(e => e.EmployeeID == employeeId);
        }

        public static Employee Get(int employeeId)
        {
            return _employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        }

        public static List<Employee> GetAll()
        {
            return _employees;
        }
    }
}