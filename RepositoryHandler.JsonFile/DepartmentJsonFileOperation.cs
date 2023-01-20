using DataEntity;
using DomainModel.Department;
using Newtonsoft.Json;
using Repository;

namespace RepositoryHandler.JsonFile
{
    public class DepartmentJsonFileOperation : IDepartmentOperation
    {
        string jsonFile = @"mydata/departmentData.json";
        public async Task<DepartmentDTO> Add(DepartmentDTO department)
        {
            //  var json = await File.ReadAllTextAsync(jsonFile);
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();

                DepartmentDTOJSonModel item = JsonConvert.DeserializeObject<DepartmentDTOJSonModel>(json);
                department.DepartmentId = item.DepartmentModel.Max(x => x.DepartmentId) + 1;

                DepartmentModel e = new DepartmentModel()
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName
                };

                item.DepartmentModel.Add(e);


                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            // await File.WriteAllTextAsync(jsonFile, newJsonResult);
            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
            return await Task.FromResult(department);
        }

        public async Task DeleteDepartmentByIdAsync(int departmentId)
        {
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json =await r.ReadToEndAsync();
                DepartmentDTOJSonModel item = JsonConvert.DeserializeObject<DepartmentDTOJSonModel>(json);
                var departmentToDeleted = item.DepartmentModel.FirstOrDefault(obj => obj.DepartmentId == departmentId);

                item.DepartmentModel.Remove(departmentToDeleted);

                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartment()
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                DepartmentDTOJSonModel item = JsonConvert.DeserializeObject<DepartmentDTOJSonModel>(json);
                List<DepartmentDTO> departments = item.DepartmentModel.Select(x => new DepartmentDTO()
                {
                    DepartmentName = x.DepartmentName,
                    DepartmentId = x.DepartmentId
                }).OrderBy(x => x.DepartmentId).ToList();
                return await Task.FromResult(departments);
            }
        }

        public async Task<DepartmentDTO> GetDepartmentById(int departmentId)
        {
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                DepartmentDTOJSonModel item = JsonConvert.DeserializeObject<DepartmentDTOJSonModel>(json);
                DepartmentDTO department = item.DepartmentModel.Where(x => x.DepartmentId == departmentId).Select(x => new DepartmentDTO()
                {
                    DepartmentName = x.DepartmentName,
                    DepartmentId = x.DepartmentId
                }).FirstOrDefault();
                return await Task.FromResult(department);
            }
        }

        public async Task<DepartmentDTO> Update(DepartmentDTO departmentChanges)
        {
            string jSONString = string.Empty;
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();

                DepartmentDTOJSonModel item = JsonConvert.DeserializeObject<DepartmentDTOJSonModel>(json);

                foreach (var department in item.DepartmentModel.Where(obj => obj.DepartmentId == departmentChanges.DepartmentId))
                {
                    department.DepartmentName = departmentChanges.DepartmentName;
                    department.DepartmentId = departmentChanges.DepartmentId;
                }

                jSONString = JsonConvert.SerializeObject(item, Formatting.Indented);
            }

            using (var streamWriter = File.CreateText(jsonFile))
            {
                streamWriter.Write(jSONString);
            }
            return await Task.FromResult(departmentChanges);
        }
    }
}
