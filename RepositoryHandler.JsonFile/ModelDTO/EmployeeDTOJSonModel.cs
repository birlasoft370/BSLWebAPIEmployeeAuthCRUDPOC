using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryHandler.JsonFile.ModelDTO
{
    public class Employee
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string? Address { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "department")]
        public string? Department { get; set; }

        [JsonProperty(PropertyName = "salary")]
        public double Salary { get; set; }
    }

    public class EmployeeDTOJSonModel
    {
        public EmployeeDTOJSonModel()
        {
            Employee = new();
        }
        [JsonProperty(PropertyName = "employee")]
        public List<Employee> Employee { get; set; }
    }
}
