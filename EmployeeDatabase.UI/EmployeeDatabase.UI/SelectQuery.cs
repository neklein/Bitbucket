using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeDatabase.UI
{
    public class SelectQuery
    {
        public List<EmployeePayRate> GetEmployeeRates()
        {
            List<EmployeePayRate> rates = new List<EmployeePayRate>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Server=localhost;Database=SWCCorp;" +
                    "User Id=sa;Password=sqlserver";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT e.EmpID, e.FirstName, e.LastName, " +
                    "pr.HourlyRate, pr.MonthlySalary, pr.YearlySalary " +
                    "FROM Employee e" +
                    "INNER JOIN PayRates pr ON e.EmpID = pr.EmpID";

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

        public void InsertGrant(string grantId, string grantName, decimal amount)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                    ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Grant] (GrantId, GrantName, EmpID, Amount)" +
                    "VALUES (@GrantId, @GrantName, null, @Amount)";

                cmd.Parameters.AddWithValue("@GrantId", grantId);
                cmd.Parameters.AddWithValue("@GrantName", grantName);
                cmd.Parameters.AddWithValue("@Amount", amount);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteGrant(string grantID)
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM [Grant]" +
                    "WHERE GrantId = @GrantId";

                cmd.Parameters.AddWithValue("@GrantId", grantID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
