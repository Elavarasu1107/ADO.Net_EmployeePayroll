using System;

namespace EmployeePayroll_ADO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeRepo getMethod = new EmployeeRepo();
            EmployeePayroll_Model model = new EmployeePayroll_Model();
            Console.WriteLine("1 to Check SQL Connectivity\n2 to Add Data to DB\n3 to view DB\nEnter a Number");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        getMethod.Connectivity();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter Name");
                        model.name = Console.ReadLine();
                        Console.WriteLine("Enter Salary");
                        model.salary = Convert.ToDouble(Console.ReadLine());
                        model.startDate = DateTime.Now;
                        Console.WriteLine("Enter Gender");
                        model.gender = Console.ReadLine(); ;
                        Console.WriteLine("Enter Phone Number");
                        model.mobile = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter Address");
                        model.address = Console.ReadLine(); ;
                        Console.WriteLine("Enter Department");
                        model.department = Console.ReadLine(); ;
                        Console.WriteLine("Enter Basic Pay");
                        model.basicPay = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Dedutions");
                        model.deductions = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Taxable Pay");
                        model.taxablePay = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Net Pay");
                        model.netPay = Convert.ToDouble(Console.ReadLine());
                        getMethod.AddEmployee(model);
                        break;
                    }
                case 3:
                    {
                        getMethod.GetAllEmployee();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter a valid Number");
                        break;
                    }
            }
        }
    }
}
