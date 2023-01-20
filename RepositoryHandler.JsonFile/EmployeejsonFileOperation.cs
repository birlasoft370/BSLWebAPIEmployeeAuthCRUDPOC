using DataEntity;
using Newtonsoft.Json;
using Repository;
using RepositoryHandler.JsonFile.ModelDTO;

namespace RepositoryHandler.JsonFile
{
    public class EmployeejsonFileOperation : IEmployeeOperation
    {
        string jsonFile = @"mydata/employeeData.json";
        public async Task<EmployeeDTO> Add(EmployeeDTO employee)
        {
            //  var json = await File.ReadAllTextAsync(jsonFile);
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();

                EmployeeDTOJSonModel item = JsonConvert.DeserializeObject<EmployeeDTOJSonModel>(json);
                employee.Id = item.Employee.Max(E => E.Id) + 1;

                Employee e = new Employee()
                {
                    Address = employee.Address,
                    Age = employee.Age,
                    Department = employee.Department,
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary
                };

                item.Employee.Add(e);


                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            // await File.WriteAllTextAsync(jsonFile, newJsonResult);
            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
            return await Task.FromResult(employee);
        }

        public async Task DeleteEmployeeByIdAsync(int employeeId)
        {
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json =await r.ReadToEndAsync();
                EmployeeDTOJSonModel item = JsonConvert.DeserializeObject<EmployeeDTOJSonModel>(json);
                var employeeToDeleted = item.Employee.FirstOrDefault(obj => obj.Id == employeeId);

                item.Employee.Remove(employeeToDeleted);

                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployee()
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                EmployeeDTOJSonModel item = JsonConvert.DeserializeObject<EmployeeDTOJSonModel>(json);
                List<EmployeeDTO> employees = item.Employee.Select(x => new EmployeeDTO()
                {
                    Address = x.Address,
                    Age = x.Age,
                    Department = x.Department,
                    Id = x.Id,
                    Name = x.Name,
                    Salary = x.Salary
                }).OrderBy(x => x.Id).ToList();
                return await Task.FromResult(employees);
            }
        }

        public async Task<EmployeeDTO> GetEmployeeById(int employeeId)
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                EmployeeDTOJSonModel item = JsonConvert.DeserializeObject<EmployeeDTOJSonModel>(json);
                EmployeeDTO employee = item.Employee.Where(x => x.Id == employeeId).Select(x => new EmployeeDTO()
                {
                    Address = x.Address,
                    Age = x.Age,
                    Department = x.Department,
                    Id = x.Id,
                    Name = x.Name,
                    Salary = x.Salary
                }).FirstOrDefault();
                return await Task.FromResult(employee);
            }
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO employeeChanges)
        {
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();

                EmployeeDTOJSonModel item = JsonConvert.DeserializeObject<EmployeeDTOJSonModel>(json);

                foreach (var employee in item.Employee.Where(obj => obj.Id == employeeChanges.Id))
                {
                    employee.Name = employeeChanges.Name;
                    employee.Salary = employeeChanges.Salary;
                    employee.Address = employeeChanges.Address;
                    employee.Age = employeeChanges.Age;
                    employee.Department = employeeChanges.Department;
                }

                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
            return await Task.FromResult(employeeChanges);
        }
    }
}