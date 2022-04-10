using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace APITests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase("Michael Silva", 198500, Description = "Verify Employee Salary")]
        public void VerifyEmployeeSalary(string employeeName, int requiredSalary)
        {
            var employees = new Employees();
            var listOfEmployees = employees.GetEmployees();

            var result = (from emp in listOfEmployees.data
                                 where emp.employee_name == employeeName
                                 select emp.employee_salary).ToList();

            int employeeSalary = 0;
            if(result.Count > 0)
            {
                foreach(int salary in result)
                {
                    employeeSalary = salary;
                }
                Assert.That(employeeSalary, Is.EqualTo(requiredSalary), $"Employee = {employeeName} has a salary of {requiredSalary}.");
            }
            else
            {
                Assert.That(employeeSalary, Is.EqualTo(requiredSalary), $"Employee = {employeeName} couldn't be found.");
            }
        }
    }
}