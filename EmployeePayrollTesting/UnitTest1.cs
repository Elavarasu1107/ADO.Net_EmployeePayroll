using EmployeePayroll_ADO;

namespace EmployeePayrollTesting
{
    [TestClass]
    public class UnitTest1
    {
        EmployeeRepo getMethod = new EmployeeRepo();
        [TestMethod]
        public void GivenMultipleEmployeeDetails_ShouldReturnTatalExecutionTime()
        {
            List<EmployeePayroll_Model> list = new List<EmployeePayroll_Model>();
            list.Add(new EmployeePayroll_Model(id: 0, name: "Thamarai", salary: 20000, startDate:new DateTime(2022,06,01), gender: "M", mobile: 9877065432, address: "Tirupur", department: "Developer", basicPay: 20000, deductions: 200, taxablePay: 500, netPay: 19500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Subash", salary: 20000, startDate: new DateTime(2022, 05, 01), gender: "M", mobile: 7123456098, address: "Coimbatore", department: "Developer", basicPay: 20000, deductions: 200, taxablePay: 500, netPay: 19500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Anand", salary: 20000, startDate: new DateTime(2022, 04, 01), gender: "M", mobile: 6543210987, address: "Neyveli", department: "Developer", basicPay: 20000, deductions: 200, taxablePay: 500, netPay: 19500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Guna", salary: 20000, startDate: new DateTime(2022, 03, 01), gender: "M", mobile: 7564321098, address: "Ariyalur", department: "Developer", basicPay: 20000, deductions: 200, taxablePay: 500, netPay: 19500));
            list.Add(new EmployeePayroll_Model(id: 0, name: "Prithiv", salary: 20000, startDate: new DateTime(2022, 02, 01), gender: "M", mobile: 8970645321, address: "MettuPalayam", department: "Developer", basicPay: 20000, deductions: 200, taxablePay: 500, netPay: 19500));
            DateTime startTime = DateTime.Now;
            getMethod.AddMultipleEmployees(list);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Time Taken: " + (endTime - startTime));
        }
    }
}