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
        public IActionResult GetByCriteria([FromQuery] SearchDepartmentsDto departmentDto)
        {
            var data = from department in departments
                       where (departmentDto.name == null || department.name.ToUpper().Contains(departmentDto.name.ToUpper())) &&
                       (departmentDto.floorNumber == null || department.floorNumber == departmentDto.floorNumber)
                       orderby department.id descending
                       select new DepartmentsDto
                       {
                           id = department.id,
                           name = department.name,
                           description = department.description,
                           floorNumber = department.floorNumber


                       };
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var data = departments.Select(x => new DepartmentsDto
            {

                id = x.id,
                name = x.name,
                description = x.description,
                floorNumber = x.floorNumber
            }).FirstOrDefault(x => x.id == id);
            if (data == null)
            {
                return NotFound("data not found");
            }
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Add([FromBody]SaveDepartmentDto departmentsDto)
        {
            var newDepartment = new Department()
            {
                id = (departments.LastOrDefault()?.id ?? 0) + 1,
                name = departmentsDto.name,
                description = departmentsDto.description,
                floorNumber = departmentsDto.floorNumber
            };
            departments.Add(newDepartment);
            return Ok(newDepartment.id);
        }
        [HttpPut]
        public IActionResult Update([FromBody]SaveDepartmentDto departmentsDto)
        {
            var department=departments.FirstOrDefault(x=>x.id== departmentsDto.id);
            if (department == null) 
            { return NotFound("DEPARTMENT NOT FOUND");
            }
            department.name = departmentsDto.name;
            department.description = departmentsDto.description;
            department.floorNumber = departmentsDto.floorNumber;
            return Ok();


        }
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var department = departments.FirstOrDefault(x => x.id == id);
            if (department == null)
            {
                return NotFound("DEPARTMENT NOT FOUND");
            }
            departments.Remove(department);
            return Ok();
        }
    }
}
   

