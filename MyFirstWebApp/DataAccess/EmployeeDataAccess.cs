using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.DataAccess
{
	public class EmployeeDataAccess
	{
		string connection = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        List<EmployeeModel> employeeDetails = new List<EmployeeModel>();

        //Get Employee Details
        public List<EmployeeModel> GetEmployee()
		{
			SqlConnection sqlConnection = new SqlConnection(connection);
			SqlCommand sqlCommand = sqlConnection.CreateCommand();
			sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
			sqlCommand.CommandText = "SPR_Employee";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			sqlDataAdapter.Fill(dataTable);
			sqlConnection.Close();

			foreach(DataRow dataRow in dataTable.Rows)
			{
				employeeDetails.Add(new EmployeeModel
				{
					EmployeeId = Convert.ToInt32(dataRow["employee_id"]),
					EmployeeName = Convert.ToString(dataRow["employee_name"]),
					Designation = Convert.ToString(dataRow["designation"]),
					Salary = Convert.ToDecimal(dataRow["salary"])
				});
			}
            return employeeDetails;
		}

		//Add the employee
		public bool AddEmployee(EmployeeModel employeeModel)
		{
            int check = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connection))
			{
				SqlCommand sqlCommand = new SqlCommand("SPC_Employee", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
				sqlCommand.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
				sqlCommand.Parameters.AddWithValue("@Designation", employeeModel.Designation);
				sqlCommand.Parameters.AddWithValue("@Salary", employeeModel.Salary);
				sqlConnection.Open();
				check = sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
				if (check > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
		}

		//Get employee by employeeid
		public List<EmployeeModel> EditEmployee(int employeeId)
		{
			using(SqlConnection sqlConnection = new SqlConnection(connection))
			{
				SqlCommand sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandText = "SPG_Employee";
				sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlConnection.Open();
				sqlDataAdapter.Fill(dataTable);
				sqlConnection.Close();

				foreach(DataRow dataRow in dataTable.Rows)
				{
					employeeDetails.Add(new EmployeeModel
					{
						EmployeeId = Convert.ToInt32(dataRow["employee_id"]),
						EmployeeName = Convert.ToString(dataRow["employee_name"]),
						Designation = Convert.ToString(dataRow["designation"]),
						Salary = Convert.ToDecimal(dataRow["salary"])
					});
				}
				return employeeDetails;
            }
		}

		//update employee detail
        public bool UpdateEmployee(EmployeeModel employeeModel)
        {
            int check = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                SqlCommand sqlCommand = new SqlCommand("SPU_Employee", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                sqlCommand.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                sqlCommand.Parameters.AddWithValue("@Designation", employeeModel.Designation);
                sqlCommand.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                sqlConnection.Open();
                check = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		//Delete employee
		public void DeleteEmployee(int id)
		{
			using(SqlConnection sqlConnection = new SqlConnection(connection))
			{
				SqlCommand sqlCommand = new SqlCommand("SPD_Employee", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
    }
}