using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace RESTSharp_Testing
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string salary { get; set; }
    }
    [TestClass]
    public class RESTSharp
    {
        RestClient client;

        [TestMethod]
        public void OnCallingGetMethod_ShouldReturnEmployeeList()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Get);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(6, list.Count);
            foreach (Employee data in list)
            {
                Console.WriteLine("{0,-5}{1,-15}{2,-10}", data.id, data.name, data.salary);
            }
        }
        [TestMethod]
        public void OnPostingEmployeeData_ShouldAddtoJsonServer()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Post);
            var body = new Employee { name = "Ravi", salary = "25000" };
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee data = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Ravi", data.name);
            Assert.AreEqual("25000", data.salary);
            Console.WriteLine(response.Content);
        }
        [TestMethod]
        public void OnPostingMultipleEmployees_SholudAddToJsonServer()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { name = "Praveen", salary = "30000" });
            list.Add(new Employee { name = "Navin", salary = "25000" });
            list.Add(new Employee { name = "Paul", salary = "30000" });
            list.ForEach(body =>
            {
                RestRequest request = new RestRequest("/employees", Method.Post);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                //Act
                RestResponse response = client.Execute(request);
                //Assert
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                Employee data = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(body.name, data.name);
                Assert.AreEqual(body.salary, data.salary);
                Console.WriteLine(response.Content);
            });
        }
    }
}