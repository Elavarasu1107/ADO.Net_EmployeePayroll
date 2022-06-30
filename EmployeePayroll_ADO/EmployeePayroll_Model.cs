using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll_ADO
{
    public class EmployeePayroll_Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public double salary { get; set; }
        public DateTime startDate { get; set; }
        public string gender { get; set; }
        public decimal mobile { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public double basicPay { get; set; }
        public double deductions { get; set; }
        public double taxablePay { get; set; }
        public double netPay { get; set; }

        public EmployeePayroll_Model(int id, string name, double salary, DateTime startDate, string gender, decimal mobile, string address, 
            string department, double basicPay, double deductions, double taxablePay, double netPay)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.startDate = startDate;
            this.gender = gender;
            this.mobile = mobile;
            this.address = address;
            this.department = department;
            this.basicPay = basicPay;
            this.deductions = deductions;
            this.taxablePay = taxablePay;
            this.netPay = netPay;
        }
    }
}
