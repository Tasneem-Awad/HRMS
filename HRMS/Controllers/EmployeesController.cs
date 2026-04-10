using HRMS.DbContexts;
using HRMS.Dtos.Employee;
using HRMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Console;
using System.Xml.Linq;
namespace HRMS.Controllers
{
    //data annotations
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly HRMSContext _dbContext;
        public EmployeesController(HRMSContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static List<Employee> employees = new List<Employee>()
        {
            new Employee(){id=1,firstName="ahmad",lastName="naser",email="hghg@djdj",position="developer",birthdate=new DateTime(2000,1,25),isActive=true,startDate=new DateTime(2026,3,3)},
            new Employee(){id=2,firstName="tasneem",lastName="ewad",email="tas@djdj",position="hr",birthdate=new DateTime(2003,1,25),isActive=true,startDate=new DateTime(2026,3,3)},
            new Employee(){id=3,firstName="ali",lastName="sami",email="ali@djdj",position="manager",birthdate=new DateTime(1999,1,25),isActive=true,startDate=new DateTime(2026,3,3)},
            new Employee(){id=4,firstName="yaser",lastName="rami",email="yaser@djdj",position="developer",birthdate=new DateTime(1997,1,25),isActive=true,startDate=new DateTime(2026,3,3)}

        };
        //Endpoint(method)
        //must be public
        //swagger

        //CRUD
        //C-->create
        //R-->Read
        //U--->update
        //D-->Delete
        [HttpGet("GetByCriteria")]
        public IActionResult GetByCriteria([FromQuery]SearchEmployeeDto employeeDto)
        {
            var data = from employee in _dbContext.Employees
                       //from department in _dbContext.Departments.Where(x=>x.id==employee.DepartmentId).DefaultIfEmpty()//left join
                       from manager in _dbContext.Employees.Where(x=>x.id==employee.ManagerId).DefaultIfEmpty()
                       where (employeeDto.Position == null || employee.position.ToUpper().Contains(employeeDto.Position.ToUpper()))&&
                       (employeeDto.Name==null|| employee.firstName.ToUpper().Contains(employeeDto.Name.ToUpper()))
                       orderby employee.id
                       select new EmployeeDto
                       {
                           id = employee.id,
                           //firstName=employee.firstName,
                           //lastName=employee.lastName,
                           name = employee.firstName + " " + employee.lastName,
                           position = employee.position,
                           birthdate = employee.birthdate,
                           startDate = employee.startDate,
                           endDate = employee.endDate,
                           DepartmentId=employee.DepartmentId,
                           //DepartmentName= department.name,
                           ManagerId=employee.ManagerId,
                           ManagerName=manager.firstName
                       };
            return Ok(data);
            // return StatusCode(200, new { Name = "ahmad", position = "developer" });
            //return Ok(new { Name = "ahmad", position = "developer" });//200 ok
            //return NotFound("employee not found");//404  not found
            //return BadRequest("DATA NOT FOUND");//400 bad request
        }
        [HttpGet("{id}")]//Route parameter
        public IActionResult GetById(long id)
        {
            //var data=_dbContext.Employees.Join(
            //    _dbContext.Departments,
            //    employee=>employee.DepartmentId,
            //    department=> department.id,
            //    (employee,department)=>new EmployeeDto
            //    {
            //        id = employee.id,
            //        name = employee.firstName + " " + employee.lastName,
            //        position = employee.position,
            //        birthdate = employee.birthdate,
            //        startdate = employee.startdate,
            //        enddate = employee.enddate,
            //        departmentid = employee.departmentid,
            //        departmentname = department.name,

            //    }
            //    ).firstordefault(x => x.id == id);
            var data = _dbContext.Employees.Select(employee => new EmployeeDto
            {
                id = employee.id,
                name = employee.firstName + " " + employee.lastName,
                position = employee.position,
                birthdate = employee.birthdate,
                startDate = employee.startDate,
                endDate = employee.endDate,
                DepartmentId = employee.DepartmentId,
                //departmentname = Department.name,
                ManagerId = employee.ManagerId,
               // managername = manager.firstname


            }).FirstOrDefault(x => x.id == id);
            //var data = employees.SingleOrDefault(x => x.id == id);
            if (data == null)
            {
                return NotFound("employee not found");
            }
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Add(SaveEmployeeDto employee)
        {
            var newEmployee = new Employee()
            {
                id =0,// (employees.LastOrDefault()?.id ?? 0) + 1,
                firstName = employee.firstName,
                lastName = employee.lastName,
                position = employee.position,
                birthdate = employee.birthdate,
                startDate = employee.startDate,
                endDate = employee.endDate,
                email = employee.email,
                isActive = employee.isActive,
                phone = employee.phone,
                salary = employee.salary,
                DepartmentId= employee.DepartmentId,
                ManagerId= employee.ManagerId
            };
            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();
            return Ok(newEmployee.id);
        }
        [HttpPut]
        public IActionResult Update(SaveEmployeeDto employeeDto)
        {
            // var employee = employees.Any(x => x.id == employeeDto.id);=> Any is bool

            var employee = _dbContext.Employees.FirstOrDefault(x => x.id == employeeDto.id);
            if (employee == null)
            {
                return NotFound("employee does not exist");
            }
            employee.firstName = employeeDto.firstName;
            employee.lastName = employeeDto.lastName;
            employee.position = employeeDto.position;
            employee.startDate = employeeDto.startDate;
            employee.endDate = employeeDto.endDate;
            employee.email = employeeDto.email;
            employee.isActive = employeeDto.isActive;
            employee.phone = employeeDto.phone;
            employee.salary = employeeDto.salary;
            employee.birthdate = employeeDto.birthdate;
            employee.DepartmentId = employeeDto.DepartmentId;
            employee.ManagerId = employeeDto.ManagerId;
            _dbContext.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.id == id);
            if (employee == null)
            {
                return NotFound("employee does nt exist");
            }
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return Ok();
        }


    }
}
//query parameter-->shows in URL
//request body-->not shows in URL
//simple data type-->string,int,long...-->query parameter
//complex data type-->Model,Dto,object..-->request body
//public IActionResult Update([FromBody]long id,[FromQuery] SaveEmployeeDto employeeDto)//to change the default
//method can use multiple parameters of type [FromQuery]
//method cannot use multiple parametrs of type[FromBody]
//Http Post/Put can use both but we use only FromBody 
//Http Get use only FromQuery or Route 
//Http Delete can use both but we use only FromQuery