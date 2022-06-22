using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll_ADO
{
    public class EmployeeRepo
    {
        public static string connectionString = "Data Source = (localdb)\\MSSQLLOCALDB;Initial Catalog = PAYROLL_SERVICE;";
        public DataSet Connectivity()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                DataSet data = new DataSet();
                using (connection)
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("ConnectivityCheck", connection);
                    adapter.Fill(data);
                    connection.Close();
                    Console.WriteLine("Connection Established");
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void GetAllEmployee()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                EmployeePayroll_Model model = new EmployeePayroll_Model();
                using (connection)
                {
                    string query = @"SELECT ID,NAME,SALARY,START_DATE,GENDER,MOBILE,ADDRESS,DEPARTMENT,BASIC_PAY,DEDUCTIONS,TAXABLE_PAY,NET_PAY
                                FROM EMPLOYEE_PAYROLL;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.id = reader.GetInt32(0);
                            model.name = reader.GetString(1);
                            model.salary = reader.GetDouble(2);
                            model.startDate = reader.GetDateTime(3);
                            model.gender = reader.GetString(4);
                            model.mobile = reader.GetDecimal(5);
                            model.address = reader.GetString(6);
                            model.department = reader.GetString(7);
                            model.basicPay = reader.GetDouble(8);
                            model.deductions = reader.GetDouble(9);
                            model.taxablePay = reader.GetDouble(10);
                            model.netPay = reader.GetDouble(11);

                            Console.WriteLine("Employee ID: " + model.id + "\n" + "Name: " + model.name + "\n" + "Start Date: " + model.startDate + "\n" + "Gender: " + model.gender + "\n" +
                               "Phone: " + model.mobile + "\n" + "Address: " + model.address + "\n" + "Department: " + model.department + "\n" + "Net Pay: " + model.netPay);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddEmployee(EmployeePayroll_Model model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NAME", model.name);
                    command.Parameters.AddWithValue("@SALARY", model.salary);
                    command.Parameters.AddWithValue("@START_DATE", model.startDate);
                    command.Parameters.AddWithValue("@GENDER", model.gender);
                    command.Parameters.AddWithValue("@MOBILE", model.mobile);
                    command.Parameters.AddWithValue("@ADDRESS", model.address);
                    command.Parameters.AddWithValue("@DEPARTMENT", model.department);
                    command.Parameters.AddWithValue("@BASIC_PAY", model.basicPay);
                    command.Parameters.AddWithValue("@DEDUCTIONS", model.deductions);
                    command.Parameters.AddWithValue("@TAXABLE_PAY", model.taxablePay);
                    command.Parameters.AddWithValue("@NET_PAY", model.netPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateTable()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using(connection)
                {
                    Console.WriteLine("Enter a Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Salary to Update");
                    double salary = Convert.ToDouble(Console.ReadLine());
                    SqlCommand command = new SqlCommand("UpdateEmployee_Payroll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NAME", name);
                    command.Parameters.AddWithValue("@BASIC_PAY", salary);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeleteData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    Console.WriteLine("Enter a Name");
                    string name = Console.ReadLine();
                    SqlCommand command = new SqlCommand("DeleteEmployee_Payroll", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NAME", name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
