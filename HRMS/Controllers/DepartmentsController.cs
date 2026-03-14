using HRMS.Dtos.Department;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Xml.Linq;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging.Console;
//using System.Xml.Linq;

namespace HRMS.Controllers
{
    //data annotations
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        public static List<Department> departments = new List<Department>()
        {
            new Department(){id=1,name="HR",description="Human Resources",floorNumber=2},
            new Department(){id=2,name="IT",description="Information Technology",floorNumber=3},
            new Department(){id=3,name="Marketing",description="market study",floorNumber=4},
        };
        [HttpGet("GetByCriteria")]
        public IActionResult GetByCriteria(String? name, int? floorNumber)
        {
            var data = from department in departments
                       where (name == null || department.name == name)
                       orderby department.id
                       select new DepartmentsDto
                       {
                           id = department.id,
                           name = department.name,
                           description = department.description,
                           floorNumber = department.floorNumber


                       };
            return Ok(data);
        }
        [HttpGet]
        public IActionResult GetById(long id)
        {
            var data = departments.Select(department => new DepartmentsDto
            {

                id = department.id,
                name = department.name,
                description = department.description,
                floorNumber = department.floorNumber
            }).FirstOrDefault(x => x.id == id);
            if(data == null) {
                return NotFound("data not found");
                    }
            return Ok(data);
        }
    }
}
   

