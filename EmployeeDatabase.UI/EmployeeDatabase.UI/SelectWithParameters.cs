﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace EmployeeDatabase.UI
{
    public class SelectWithParameters
    {
        public List<EmployeePayRate> GetEmployeeRates(string city)
        {
            List<EmployeePayRate> rates = new List<EmployeePayRate>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=SWCCorp;" +
                    "User Id=sa;Password=sqlserver";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT e.EmpID, e.FirstName, e.LastName, " +
                    "pr.HourlyRate, pr.MonthlySalary, pr.YearlySalary " +
                    "FROM Employee e" +
                    "INNER JOIN PayRates pr ON e.EmpID = pr. EmpID" +
                    "INNER JOIN [Location] l ON e.LocationID = l.LocationID" +
                    "WHERE l.City = @city";

                cmd.Parameters.AddWithValue("@city", city);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EmployeePayRate currentRow = new EmployeePayRate();

                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();

                        if (dr["HourlyRate"] != DBNull.Value)
                            currentRow.HourlyRate = (decimal)dr["HourlyRate"];

                        if (dr["MonthlySalary"] != DBNull.Value)
                            currentRow.MonthlySalary = (decimal)dr["MonthlySalary"];

                        if (dr["YearlySalary"] != DBNull.Value)
                            currentRow.YearlySalary = (decimal)dr["YearlySalary"];

                        currentRow.EmpID = (int)dr["EmpID"];
                        rates.Add(currentRow);
                    }
                }
            }

            return rates;
        }
    }
}
