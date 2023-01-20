using Newtonsoft.Json;

namespace DomainModel.Department
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }


    public class DepartmentDTOJSonModel
    {
        public DepartmentDTOJSonModel()
        {
            DepartmentModel = new();
        }
        [JsonProperty(PropertyName = "department")]
        public List<DepartmentModel> DepartmentModel { get; set; }
    }
}
