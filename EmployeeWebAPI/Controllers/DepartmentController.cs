using DomainModel.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string query = @"
                    select DepartmentId, DepartmentName from dbo.Department";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeDBConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                await myCon.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = await myCommand.ExecuteReaderAsync();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            List<DepartmentModel> deptlist = new List<DepartmentModel>();
            deptlist = table.AsEnumerable().Select(x => new DepartmentModel()
            {
                DepartmentId = (int)x["DepartmentId"],
                DepartmentName = (string)x["DepartmentName"]
            }).ToList();

            return Ok(deptlist);
        }


        [HttpPost]
        public async Task<IActionResult> Post(DepartmentModel dep)
        {
            string query = @"
                    insert into dbo.Department values 
                    ('" + dep.DepartmentName + @"')
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeDBConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                await myCon.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = await myCommand.ExecuteReaderAsync();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return Ok("Added Successfully");
        }


        [HttpPut]
        public async Task<IActionResult> Put(DepartmentModel dep)
        {
            string query = @"
                    update dbo.Department set 
                    DepartmentName = '" + dep.DepartmentName + @"'
                    where DepartmentId = " + dep.DepartmentId + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeDBConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                await myCon.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = await myCommand.ExecuteReaderAsync();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return Ok("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string query = @"
                    delete from dbo.Department
                    where DepartmentId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeDBConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                await myCon.OpenAsync();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = await myCommand.ExecuteReaderAsync();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return Ok("Deleted Successfully");
        }

    }
}
