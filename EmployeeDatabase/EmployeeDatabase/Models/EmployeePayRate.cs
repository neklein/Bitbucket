﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDatabase.Models
{
    public class EmployeePayRate
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal? MonthlySalary { get; set; }
        public decimal? YearlySalary { get; set; }
    }
}