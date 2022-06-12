using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRoll
{
    class EmployeeRepo
    {
        public static string ConnectionString = "Server=ARSHAD-LAP; Initial Catalog=PayRole_Service; Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);
        public void GetAllEmployees()
        {
            EmployeeModel employeeModel = new EmployeeModel();

            try
            {
                using (this.connection)
                {
                    string query = @"Select * from Employee_PayRoll_table";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeId = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.Phone_Number = Convert.ToInt64(dr[2]);
                            employeeModel.Address = dr.GetString(3);
                            employeeModel.Department = dr.GetString(4);
                            employeeModel.Gender = dr.GetChar(5);
                            employeeModel.Basic_Pay = dr.GetDouble(6);
                            employeeModel.Deductions = dr.GetDouble(7);
                            employeeModel.Taxable_Pay = dr.GetDouble(8);
                            employeeModel.Tax = dr.GetDouble(9);
                            employeeModel.Net_Pay = dr.GetDouble(10);
                            employeeModel.StartDate = dr.GetDateTime(11);
                            employeeModel.City = dr.GetString(12);
                            employeeModel.Country = dr.GetString(13);

                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
