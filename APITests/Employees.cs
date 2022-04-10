using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APITests
{
    public class Employees
    {
        public ListOfEmployees GetEmployees()
        {

            // arrange
            RestClient restClient = new RestClient("http://dummy.restapiexample.com/api/v1");
            RestRequest restRequest = new RestRequest("/employees", Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            // act
            IRestResponse response = restClient.Execute(restRequest);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var content = response.Content;
            var employees = JsonConvert.DeserializeObject<ListOfEmployees>(content);
            return employees;
        }
    }
}
