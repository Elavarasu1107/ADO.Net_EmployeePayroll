using System;

namespace EmployeePayroll_ADO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeRepo getMethod = new EmployeeRepo();
            getMethod.Connectivity();
        }
    }
}
